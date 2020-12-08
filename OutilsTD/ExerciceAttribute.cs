using System;

namespace OutilsTD
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExerciceAttribute : Attribute
    {
        public string nomExercice;

        public ExerciceAttribute(string nomExercice)
        {
            this.nomExercice = nomExercice;
        }
    }
}
