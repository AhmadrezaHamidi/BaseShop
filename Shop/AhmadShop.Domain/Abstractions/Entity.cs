using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        ModifyAt = null;
    }

    protected Entity()
    {
    }

    public Guid Id { get; set; }
    public bool IsDeleted { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? ModifyAt { get; init; }
}
