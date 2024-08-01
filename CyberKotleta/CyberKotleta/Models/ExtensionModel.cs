using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberKotleta.Models
{

    public partial class CyberAthlete
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

    //public partial class CyberAthlete
    //{
    //    public string PhotoFull
    //    {
    //        get
    //        {
    //            if (this.PhotoFull == null)
    //            {
    //                return null;
    //            }

    //            else
    //            {
    //                string namePhoto = Directory.GetCurrentDirectory() + "\\image\\" + PhotoFull;
    //                return namePhoto;
    //            }
    //        }
    //    }
    //}
}
