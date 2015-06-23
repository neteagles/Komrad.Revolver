namespace Komrad.Revolver.Annotations.Actions
{
    using System;

    public class ReplaceAction : ConditionalAction
    {
        public ReplaceAction(string placeholder, string value, string raw)
            : base(raw)
        {
            if (placeholder == null)
                throw new ArgumentNullException(nameof(placeholder));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Placeholder = placeholder;
            Value = value;
        }

        public string Placeholder { get; }
        public string Value { get; }
    }
}