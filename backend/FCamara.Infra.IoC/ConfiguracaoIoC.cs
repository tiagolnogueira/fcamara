using Autofac;
using Autofac.Integration.WebApi;
using FCamara.Comum;
using FCamara.Dominio.Repositorios;
using FCamara.Infra.Repositorios;
using FCamara.ServicoAutenticacao.Contratos.Contratos;
using FCamara.ServicoAutenticacao.Contratos.Impl;
using FCamara.Servicos.Contratos;
using FCamara.Servicos.Contratos.Impl;
using System.Web.Http.Dependencies;

namespace FCamara.Infra.IoC
{
    public class ConfiguracaoIoC<T> where T : class
    {
        public ConfiguracaoIoC(T applicationClass) : base()
        {
            _applicationClass = applicationClass;
            _containerBuilder = new ContainerBuilder();
        }

        private AutofacWebApiDependencyResolver _resolver;
        private static T _applicationClass;
        public IContainer Container { get; private set; }
        internal readonly ContainerBuilder _containerBuilder;

        internal static ConfiguracaoIoC<T> _instancia;

        public static ConfiguracaoIoC<T> Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ConfiguracaoIoC<T>(_applicationClass);

                return _instancia;
            }
        }

        public IDependencyResolver WebApiDependencyResolver
        {
            get
            {
                return _resolver = _resolver ?? new AutofacWebApiDependencyResolver(Container);
            }
        }

        private void BuildContainer()
        {
            Container = _containerBuilder.Build();
        }

        public void RegistrarDependencias()
        {
            var applicationType = typeof(T);
            _containerBuilder.RegisterApiControllers(applicationType.Assembly).InstancePerRequest();

            _containerBuilder.RegisterType<FCamaraContexto>().As<IDbContext>().InstancePerRequest();
            _containerBuilder.RegisterGeneric(typeof(Repositorio<>)).As(typeof(IRepositorio<>)).InstancePerRequest();
            _containerBuilder.RegisterType<ServicoProduto>().As<IServicoProduto>().InstancePerRequest();
            _containerBuilder.RegisterType<ServicoUsuario>().As<IServicoUsuario>().InstancePerRequest();
            

            BuildContainer();
        }
    }
}