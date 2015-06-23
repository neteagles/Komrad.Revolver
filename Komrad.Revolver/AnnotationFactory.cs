namespace Komrad.Revolver
{
    using System;
    using System.Text.RegularExpressions;
    using Annotations;
    using Annotations.Actions;

    public class AnnotationFactory
    {
        private static readonly Regex ConditionAnnotationPattern
            = new Regex(@"//\s*@Komrad.Revolver\s+If:\s*(?<condition>[^\s]+)(\s+Then:\s*(?<action>[^\s]+))?");

        public Annotation Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException(nameof(input));

            var match = ConditionAnnotationPattern.Match(input);
            if (match.Success)
            {
                var condition = match.Groups["condition"].Value;
                var action = new ConditionalActionFactory().Create(match.Groups["action"].Value);

                return new ConditionalAnnotation(condition, action);
            }

            return null;
        }

        
    }

    public class ConditionalActionFactory
    {
        private static readonly Regex ReplaceActionPattern
            = new Regex(@"\[(?<placeholder>[^\]^\s]+)\]=(?<value>[^\s]+)");

        public ConditionalAction Create(string input)
        {
            var match = ReplaceActionPattern.Match(input);
            if (match.Success)
            {
                var placeholder = match.Groups["placeholder"].Value;
                var value = match.Groups["value"].Value;

                return new ReplaceAction(placeholder, value, input);
            }

            return null;
        }
    }
}