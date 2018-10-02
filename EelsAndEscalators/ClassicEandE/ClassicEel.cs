using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{
    //Nico
    public class ClassicEel : IEntity
    {
        public int top_location { get ;set; }
        public int bottom_location { get; set; }
        public EntityType type => EntityType.Eel;

        public long Id { get; set; }

        private readonly IPawn _pawn;

        public ClassicEel(IPawn pawn)
        {
            _pawn = pawn;
        }

        public ClassicEel()
        {

        }

        public void SetPawn()
        {
            try
            {
                _pawn.location = bottom_location;
            }
            catch
            {
                //may need a better Exception 
                throw new Exception();
            }
        }

        public bool OnSamePositionAs()
        {
            try
            {
                return top_location == _pawn.location ? true : false;
            }
            catch
            {
                //may need a better Exception 
                throw new Exception();
            }
        }
    }
}
