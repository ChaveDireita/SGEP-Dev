﻿using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Services.Repository
{
    public interface IAlmoxarifadoRepository : IRepository<Almoxarifado>
    {
        void Remove (Almoxarifado model);
    }
}
