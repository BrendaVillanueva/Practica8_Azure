﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;


namespace Practica8_Azure
{
   public interface ISQLAzure
    {
        Task<bool> Authenticate(); //QUE AUTENTIQUE PARA CADA PLATAFORMA 
    }
}
