﻿using DeployHours.Gate.Models;
using DeployHours.Gate.Rules;
using GitHubActions.Gates.Framework.Models.WebHooks;

namespace DeployHours.Gate.Tests.Helpers
{
    /// <summary>
    /// Wrapper to allow testing of the protected method
    /// </summary>
    public class DeployHoursGateTestableWrapper : ProcessFunction
    {
        public DeployHoursRulesEvaluator Rules { get; private set; }

        public DeployHoursGateTestableWrapper(DeployHoursRulesEvaluator rules)
        {
            this.Rules = rules;
        }

        protected override DeployHoursRulesEvaluator RulesFactory(DeployHoursConfiguration cfg)
        {
            return Rules;
        }

        public async Task CallProcess(DeploymentProtectionRuleWebHook webhook)
        {
            await Process(webhook);
        }
    }
}
