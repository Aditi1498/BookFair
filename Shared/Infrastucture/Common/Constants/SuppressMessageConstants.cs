namespace Shared
{
    /// <summary>
    /// Contains Suppress Message Constants for FxCop.    
    /// Author: Nagarro
    /// </summary>
    public static class SuppressMessageConstants
    {
        public const string DesignCategory = "Microsoft.Design";
        public const string PerformanceCategory = "Microsoft.Performance";
        public const string NamingCategory = "Microsoft.Naming";
        public const string UsageCategory = "Microsoft.Usage";
        public const string GlobalizationCategory = "Microsoft.Globalization";


        public const string NestedTypeShouldNotBeVisible = "CA1034:NestedTypesShouldNotBeVisible";

        public const string OverrideEqualsAndOperatorEqualsOnValueTypes =
            "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes";

        public const string TypeNamesShouldNotMatchNamespaces = "CA1724:TypeNamesShouldNotMatchNamespaces";
        public const string MarkEnumsRule = "CA1027:MarkEnumsWithFlags";
        public const string IdentifiersShouldHaveCorrectSuffix = "CA1710:IdentifiersShouldHaveCorrectSuffix";
        public const string MarkAssembliesWithClsCompliant = "CA1014:MarkAssembliesWithClsCompliant";
        public const string MarkMembersAsStatic = "CA1822:MarkMembersAsStatic";
        public const string DoNotDeclareStaticMembersOnGenericTypes = "CA1000:DoNotDeclareStaticMembersOnGenericTypes";
        public const string AvoidEmptyInterfaces = "CA1040:AvoidEmptyInterfaces";
        public const string IdentifiersShouldNotMatchKeywords = "CA1716:IdentifiersShouldNotMatchKeywords";

        public const string InitializeReferenceTypeStaticFieldsInline =
            "CA1810:InitializeReferenceTypeStaticFieldsInline";

        public const string NonConstantFieldsShouldNotBeVisible = "CA2211:NonConstantFieldsShouldNotBeVisible";
        public const string GenericMethodsShouldProvideTypeParameter = "CA1004:GenericMethodsShouldProvideTypeParameter";
        public const string DoNotPassTypesByReference = "CA1045:DoNotPassTypesByReference";
        public const string IdentifiersShouldBeCasedCorrectly = "CA1709:IdentifiersShouldBeCasedCorrectly";
        public const string SpecifyIFormatProvider = "CA1305:SpecifyIFormatProvider";

        public const string DoNotCallOverridableMethodsInConstructors =
            "CA2214:DoNotCallOverridableMethodsInConstructors";

        public const string DoNotRaiseExceptionsInUnexpectedLocations =
            "CA1065:DoNotRaiseExceptionsInUnexpectedLocations";

        public const string ReviewUnusedParameters = "CA1801:ReviewUnusedParameters";
        public const string CompoundWordsShouldBeCasedCorrectly = "CA1702:CompoundWordsShouldBeCasedCorrectly";
        public const string PropertiesShouldNotReturnArrays = "CA1819:PropertiesShouldNotReturnArrays";
        public const string UriParametersShouldNotBeStrings = "CA1054:UriParametersShouldNotBeStrings";
        public const string AvoidNamespacesWithFewTypes = "CA1020:AvoidNamespacesWithFewTypes";
        public const string ConsiderPassingBaseTypesAsParameters = "CA1011:ConsiderPassingBaseTypesAsParameters";

        public const string UsePreferredTerms = "CA1726:UsePreferredTerms";
    }
}