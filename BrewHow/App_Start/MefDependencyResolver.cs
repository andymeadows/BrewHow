using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Mvc;


namespace BrewHow
{
    public class MefDependencyResolver : IDependencyResolver
    {
        private ExportProvider _exportProvider;

        public MefDependencyResolver(ExportProvider exportProvider)
        {
            this._exportProvider = exportProvider;
        }

        public object GetService(Type serviceType)
        {
            var export = this
                ._exportProvider
                .GetExports(serviceType, null, null)
                .SingleOrDefault();

            if (export != null)
            {
                return export.Value;
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var exports = this
                ._exportProvider
                .GetExports(serviceType, null, null);

            foreach (var export in exports)
            {
                yield return export.Value;
            }
        }
    }
}
