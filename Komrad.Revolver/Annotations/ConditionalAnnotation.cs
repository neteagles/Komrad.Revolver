namespace Komrad.Revolver.Annotations
{
    using System;
    using Actions;

    public class ConditionalAnnotation : Annotation
    {
        public ConditionalAnnotation(string condition, ConditionalAction action)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            Condition = condition;
            Action = action;
        }

        public string Condition { get; }
        public ConditionalAction Action { get; }
    }
}