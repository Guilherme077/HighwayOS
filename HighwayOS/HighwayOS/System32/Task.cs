using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32
{
    public class Task
    {
        /// <summary>Name used to create/delete/show the task</summary>
        /// <remarks>
        /// The Name() have to be 'override'. Without this, the task will be named as 'unknown'
        /// </remarks>
        public virtual String Name() {return "unknown"; }

        /// <summary>The TaskManager runs Execute() every cycle. </summary>
        /// <remarks>
        /// The Execute() have to be 'override'. The code placed here will execute only when the task is running
        /// </remarks>
        public virtual void Execute()
        {

        }
    }
}
