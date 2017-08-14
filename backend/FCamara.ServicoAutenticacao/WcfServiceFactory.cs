using FCamara.ServicoAutenticacao.Contratos;
using FCamara.ServicoAutenticacao.Contratos.Impl;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace FCamara.ServicoAutenticacao
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            container
               .RegisterType<IServicoToken, ServicoToken>();
        }
    }    
}