using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Clock_App
{
    public class Clock
    {
        public delegate void OnChangeSecondHandle();
        public event  OnChangeSecondHandle OnChangeSecondEvent;

       public void Fire(){
           if(OnChangeSecondEvent!=null){
                 OnChangeSecondEvent();              
           }
       }
     
        

        
    }
}