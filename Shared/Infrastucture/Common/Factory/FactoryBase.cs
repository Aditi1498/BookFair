using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace Shared
{
    /// <summary>
    /// Represents the abstract base class for all factories,
    /// </summary>
    public abstract class FactoryBase
    {
        /// <summary>
        /// Stores the path of assemblies source folder
        /// </summary>
        private static readonly string _assembliesPath = GetAssembliesSourceOutputBinPath();

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryBase"/> class.
        /// </summary>
        protected FactoryBase()
        {
        }

        #endregion

        /// <summary>
        /// Creates the instance of type present in specified assembly file name.
        /// </summary>
        /// <param name="assemblyFileName">Name of the assembly file.</param>
        /// <param name="qualifiedTypeName">Qualified name of the type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        protected object CreateObjectInstance(string assemblyFileName, string qualifiedTypeName, params object[] args)
        {
            object instance = null;

            try
            {
                Assembly sourceAssembly = this.LoadAssembly(assemblyFileName);

                // create the instance of using qualified type name passed as parameter
                if (args != null && args.Length > 0)
                {
                    instance = sourceAssembly.CreateInstance(qualifiedTypeName, true, BindingFlags.CreateInstance, null, args, null, null);
                }
                else
                {
                    instance = sourceAssembly.CreateInstance(qualifiedTypeName, true);
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                throw new FactoryException(string.Format("Assembly '{0}' not found !", assemblyFileName), fnfEx);
            }
            catch (Exception ex)
            {
                throw new FactoryException(string.Format("Error while creating instance of '{0}' existing in assembly '{1}' !", qualifiedTypeName, assemblyFileName), ex);
            }

            // return
            return instance;
        }

        #region Private Methods

        /// <summary>
        /// Loads the assembly.
        /// </summary>
        /// <param name="assemblyFileName">Name of the assembly file.</param>
        private Assembly LoadAssembly(string assemblyFileName)
        {
            // get if assembly is the currently executing one.
            Assembly sourceAssembly = this.GetIfExecutingAssembly(assemblyFileName);

            // Load assembly form passed parameter if it is not found as currently executing one.
            if (sourceAssembly == null)
            {
                sourceAssembly = Assembly.LoadFrom(_assembliesPath + assemblyFileName);
            }

            return sourceAssembly;
        }

        /// <summary>
        /// Gets the assemblies source output bin path.
        /// </summary>
        /// <returns></returns>
        private static string GetAssembliesSourceOutputBinPath()
        {
            string pathToProbe = System.AppDomain.CurrentDomain.BaseDirectory;
            string pathToCheck = string.Empty;

            bool isPathFound = false;
            while (!isPathFound)
            {
                DirectoryInfo dInfo = Directory.GetParent(pathToProbe);
                if (dInfo != null)
                {
                    pathToProbe = dInfo.FullName;
                    pathToCheck = pathToProbe + "\\" + AppConstants.ConfigurationKeys.OutputBinFolderName;

                    if (Directory.Exists(pathToCheck))
                    {
                        isPathFound = true;
                    }
                }
                else
                {
                    throw new FactoryException(string.Format("Path for source assemblies not found ! Path: {0}", pathToCheck));
                }
            }

            return pathToCheck + Path.DirectorySeparatorChar;
        }

        /// <summary>
        /// Gets if current assembly.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private Assembly GetIfExecutingAssembly(string assemblyName)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            string name = currentAssembly.GetName().Name + ".dll";
            if (!name.Equals(assemblyName))
            {
                currentAssembly = null;
            }

            return currentAssembly;
        }
        #endregion
    }
}
