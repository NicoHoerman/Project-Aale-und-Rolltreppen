using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{

    public class ClassicEscalator : IEntity
    {
        public int top_location { get; set; }
        public int bottom_location { get; set; }

        public EntityType type => EntityType.Escalator;

        public long Id { get; set; }

        private readonly IPawn _pawn;

        public ClassicEscalator(IPawn pawn)
        {
            _pawn = pawn;
        }

        public ClassicEscalator()
        {

        }

        public void SetPawn()
        {
            try
            {
                _pawn.location = top_location;
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
                return bottom_location == _pawn.location ? true : false;
            }
            catch
            {
                //may need a better Exception 
                throw new Exception();
            }
        }
    }
}
