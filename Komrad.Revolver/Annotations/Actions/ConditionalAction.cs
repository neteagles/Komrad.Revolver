namespace Komrad.Revolver.Annotations.Actions
{
    using System;

    public abstract class ConditionalAction
    {
        protected ConditionalAction(string raw)
        {
            if (raw == null)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
        }

        public string Raw { get; }
    }
}