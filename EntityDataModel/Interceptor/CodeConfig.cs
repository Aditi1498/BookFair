using System.Data.Entity;

namespace EntityDataModel.Interceptor
{
    class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            this.AddInterceptor(new CommandInterceptor());
        }
    }
}
