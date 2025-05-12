using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj) =>
            obj is User user && Id == user.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}
