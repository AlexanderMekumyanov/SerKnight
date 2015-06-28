using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface IPhysicableActor
{
    void Move();
    void PhysicsUpdate();
    void InitPhysics();
}