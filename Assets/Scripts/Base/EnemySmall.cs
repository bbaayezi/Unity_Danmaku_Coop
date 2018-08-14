using System.Collections;
using System.Collections.Generic;
using Project.Standard.Abstract;
using UnityEngine;

namespace Project.Standard.Base
{
    public class EnemySmall
    {
        public string EnemyType { get; set; }
        private int Life { get; set; }
        private int Id { get; set; }
        public EnemySmall(string type, int life, int id)
        {
            EnemyType = type;
            Life = life;
            Id = id;
        }
    }
}
