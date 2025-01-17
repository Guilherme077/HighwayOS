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
        public virtual string Name() {return "unknown"; }

        /// <summary>Name used call the task in commands</summary>
        /// <remarks>
        /// This is an easy name that will be used by CmdProcessor and other applications to use the task. If not override, the CmdName will be the name in lowercase
        /// </remarks>
        public virtual string CmdName() { return Name().ToLower(); }

        /// <summary>If the TaskManager will allow multiple tasks</summary>
        /// <remarks>
        /// The AllowOnlyOne() don't need to be 'override'. The defaul value is 'false'
        /// </remarks>
        public virtual bool AllowOnlyOne() { return false; }

        /// <summary>The TaskManager runs Execute() every cycle. </summary>
        /// <remarks>
        /// The Execute() have to be 'override'. The code placed here will execute only when the task is running
        /// </remarks>
        public virtual void Execute()
        {

        }

        /// <summary>The TaskManager runs OnStart() once in the task start. </summary>
        /// <remarks>
        /// The OnStart() have to be 'override'. The code placed here will execute only when the task is started.
        /// </remarks>
        public virtual void OnStart()
        {

        }

        /// <summary>There is the commands of the task with args</summary>
        /// <remarks>
        /// The CommandProcessor can call the command when the User types a command with this task, bu can be called by another application.
        /// </remarks>
        public virtual void Command(string[] args)
        {

        }
    }
}
