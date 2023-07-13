using System;
using System.Reflection;

namespace Integrando_Apis_con_ADO.NET.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}