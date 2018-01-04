namespace EASolution.Infrastructure.Service.Proxy
{
    public class ServiceFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="service">
        /// The IEntityService.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Create<T>(T service) where T : IService
        {

            var decoratedRepository = (T)new DynamicProxy<T>(service).GetTransparentProxy();
            // Create a dynamic proxy for the class already decorated
            decoratedRepository = (T)new AuthenticationProxy<T>(decoratedRepository).GetTransparentProxy();
            return decoratedRepository;
        }
    }
    public class ServiceFactoryWithFilter
    {
        public static T CreateWithoutGetMethod<T>(T service)
        {
            var dynamicProxy = new FilterDynamicProxy<T>(service)
            {
                Filter = m => !m.Name.StartsWith("Get", System.StringComparison.Ordinal)
            };
            return (T)dynamicProxy.GetTransparentProxy();
        }
    }
}