using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
    public  class EntityBase<Tkey> 
    {
        public Tkey Id { get; set; }

        public override bool Equals(object obj)
        {
            var @base = obj as EntityBase<Tkey>;
            return @base != null &&
                   EqualityComparer<Tkey>.Default.Equals(Id, @base.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<Tkey>.Default.GetHashCode(Id);
        }
    }
}
