using Microsoft.Extensions.DependencyInjection;
using MyTestHibernate.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.Attributes;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace MyTestHibernate
{
    public static class NHibernateHelper
    {

        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {

            var configuration = new Configuration();

            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                //c.SchemaAction = SchemaAutoAction.Validate;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });


            HbmSerializer.Default.Validate = true;

            var stream = HbmSerializer.Default.Serialize(Assembly.GetAssembly(typeof(Book)));
            configuration.AddInputStream(stream);


            ISessionFactory _sessionFactory = configuration.BuildSessionFactory();

            //Позволяет Nhibernate самому создавать в БД таблицу и поля к ним. 
            //new SchemaUpdate(configuration).Execute(true, true);

            services.AddSingleton(_sessionFactory);
            services.AddScoped(factory => _sessionFactory.OpenSession());


            //services.AddSingleton<ISessionFactory>((provider) => {
            //    return provider.GetService<Configuration>().BuildSessionFactory();
            //});

            //services.AddScoped<ISession>((provider) => {
            //    return provider.GetService<ISessionFactory>().OpenSession();
            //});


            return services;
        }



    }
}
