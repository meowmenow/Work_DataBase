using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonentuzik
{
    public partial class Abonent
    {
        public string PhotoFull
        {
            get
            {
                if (this.Photo == null)
                {
                    return null;
                }
                else
                {
                    string namePhoto = Directory.GetCurrentDirectory() + "\\image\\" + Photo;
                    return namePhoto;
                }
            }
        }
    }
}
