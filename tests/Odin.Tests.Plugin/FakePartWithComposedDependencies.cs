﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Composition;
using BadEcho.Odin.Extensibility.Hosting;
using BadEcho.Odin.Tests.Extensibility;

namespace BadEcho.Odin.Tests.Plugin
{
    [Export(typeof(IFakePartWithComposedDependencies))]
    public class FakePartWithComposedDependencies : IFakePartWithComposedDependencies
    {
        private const string DEPENDENCY_CONTRACT = "ComposedDependency";

        [ImportingConstructor]
        public FakePartWithComposedDependencies([Import(DEPENDENCY_CONTRACT)]IFakeDependency dependency)
        {
            Dependency = dependency;
        }

        public IFakeDependency Dependency { get; }

        [Export(typeof(IConventionProvider))]
        private class LocalDependencyRegistry : DependencyRegistry<IFakeDependency>
        {
            public LocalDependencyRegistry()
                : base(DEPENDENCY_CONTRACT)
            { }
        }
    }
}
