using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Common;
using $safeprojectname$.Repositories;
using $safeprojectname$.Repositories.Dos;
using $safeprojectname$.Services.Account;
using $safeprojectname$.Services.File;
using $safeprojectname$.Services.Person;
using $safeprojectname$.Services.Post;
using $safeprojectname$.Services.Store;

namespace $safeprojectname$.Configs
{
    public class DataAccessServiceConfig
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            // Usually you're only interested in exposing the type
            // http://stackoverflow.com/questions/15226536/register-generic-type-with-autofac
            // via its interface:
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<PostService>().As<IPostService>();
            builder.RegisterType<StoreService>().As<IStoreService>();
            builder.RegisterType<FileService>().As<IFileService>();

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();

            //builder.RegisterGeneric(typeof(BaseRepository<>)).AsSelf();
            builder.RegisterType<PersonRepository>().As<BaseRepository<PersonDo>>();
            builder.RegisterType<AccountRepository>().As<BaseRepository<AccountDo>>();
            builder.RegisterType<StoreRepository>().As<BaseRepository<StoreDo>>();
            //builder.RegisterType<FileRepository>().As<BaseRepository<FileDo>>();
            builder.RegisterType<FileRepository>().As<IFileRepository>();

            // Provider
            builder.RegisterType<HttpClientProvider>().As<IHttpClientProvider>();

            //builder.RegisterType<PersonRepository>().As<IBaseRepository>();
            // However, if you want BOTH services (not as common)
            // you can say so:
            //builder.RegisterType<IAccountService>().AsSelf().As<IService>();

        }
    }
}
