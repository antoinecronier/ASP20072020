using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module2_P1
{
    public class User : UserInterface
    {
        #region Java
        private string name;

        /// <summary>
        /// Java name mutator.
        /// </summary>
        /// <param name="name"></param>
        public void setName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Java name accessor.
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return this.name;
        }
        #endregion

        #region C#
        #region PropFull
        private string name1;

        public string Name1
        {
            get { return name1; }
            set { name1 = value; }
        }

        private string name2;

        public string Name2
        {
            get
            {
                if (name2.Length > 10)
                {
                    return "test";
                }
                return name2;
            }
            set
            {
                if (value.Equals("test"))
                {

                }
                name2 = value;
            }
        }
        #endregion
        #region Auto property
        public string Name3 { get; set; }
        #endregion
        #region Implemented property
        private string password;
        public string Password { get => this.password; set => this.password = value; }
        #endregion
        #endregion
    }
}
