using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Application.ExternalInterfaces.DbConteracts;

public interface ICHMSDbContext
{
    //DbSet<RejectionReason> RejectionReasons { get; set; }
    //DbSet<Cheque> Cheques { get; }
    //DbSet<ChequeOwner> AccuntOwners { get; }
    //DbSet<Person> Persons { get; }
    //DbSet<Receiver> Receivers { get; }
    //DbSet<Signer> Signers { get; }

    //DbSet<RejectionReason> RejectionReasons { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}