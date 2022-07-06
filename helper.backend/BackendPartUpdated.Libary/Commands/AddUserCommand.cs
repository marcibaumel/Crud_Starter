﻿using BackendPartUpdated.DataManagment.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Commands
{
    public record AddUserCommand(UserEntity entity) : IRequest<UserEntity>
    {
    }
}