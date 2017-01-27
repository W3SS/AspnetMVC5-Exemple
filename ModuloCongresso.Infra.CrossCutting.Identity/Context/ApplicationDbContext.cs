using System;
using Microsoft.AspNet.Identity.EntityFramework;
using ModuloCongresso.Infra.CrossCutting.Identity.Model;

namespace ModuloCongresso.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("ModuloCongressoConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
