using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waggle.Biz
{
    
    
    public enum EntityStateOption
    {
    Active,
    Deleted,
    Test
    }

    public abstract class EntityBase

    {
        public EntityStateOption EntityState { get; set; }

        public bool HasChanges { get; set; }

        public bool IsNew { get; private set; }

        public bool IsValid
        {
            get
            {
                return Validate();
            }


        }

        public abstract bool Validate();
    }

   
    

    


}
