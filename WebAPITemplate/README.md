# CW-WebApiStarter Template

  

* Add the Final Template "WebAPI.Example.Template.zip" into C:\Users\USERNAME\Documents\Visual Studio 2015\Templates\ProjectTemplates\Visual C#
* Open Visual Studio and find the PokeBall
* Update all of the NuGet Packages : Update-Package -Reinstall
* File 'App_Start\SwaggerConfig.cs' already exists in project 'WebAPISample._____'. Do you want to overwrite it?
  [Y] Yes  [A] Yes to All  [N] No  [L] No to All  [?] Help (default is "N"):y
* Update Project set the start page to be swagger/ui/index
* SPECS Project Update Specs by replaceing WebExample with ProjectName in whole project and updating the references to be ProjectName.dll and ProjectName.DataAccess.dll
* Update the API Porject and set the web startup page to be swagger/ui/index


## Creating the template

1. Some Help (https://blog.jayway.com/2015/03/13/visual-studio-how-to-create-a-solution-template-with-multiple-projects/)	
2. Export all projects into zips
3. Unzip all projects and create a master template that references each project folders template
Master Template 
```
 <VSTemplate Version="3.0.0" Type="ProjectGroup" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005">
  <TemplateData>
    <Name>WebAPI Sample Template</Name>
    <Description>WebAPI Sample Solution Template</Description>
    <ProjectType>CSharp</ProjectType>
    <ProjectSubType>
    </ProjectSubType>
    <SortOrder>1000</SortOrder>
    <CreateNewFolder>true</CreateNewFolder>
    <DefaultName>WebAPISample</DefaultName>
    <ProvideDefaultName>true</ProvideDefaultName>
    <LocationField>Enabled</LocationField>
    <EnableLocationBrowseButton>true</EnableLocationBrowseButton>
    <Icon>Poke_Ball_icon.png</Icon>
  </TemplateData>
  <TemplateContent>
	<ProjectCollection>
	 <ProjectTemplateLink ProjectName="$projectname$">
                WebExample\MyTemplate.vstemplate
            </ProjectTemplateLink>
            <ProjectTemplateLink ProjectName="$projectname$.DataAccess">
                WebExample.DataAccess\MyTemplate.vstemplate
            </ProjectTemplateLink>
            <ProjectTemplateLink ProjectName="$projectname$.Common">
                WebExample.Common\MyTemplate.vstemplate
            </ProjectTemplateLink>
			<ProjectTemplateLink ProjectName="$projectname$.SQL">
                WebExample.SQL\MyTemplate.vstemplate
            </ProjectTemplateLink>
			<ProjectTemplateLink ProjectName="$projectname$.Specs">
                WebExample.Specs\MyTemplate.vstemplate
            </ProjectTemplateLink>
        </ProjectCollection>
  </TemplateContent>
</VSTemplate>

```

4. Update each project name in the master template to to be $projectname$"
5. Update each project.csproj file and replace the OriginalProjectName with $safeprojectname$
6. Make sure that the package folders heirarchy matches that of the final template solution otherwise (https://stackoverflow.com/questions/32254439/nuget-packages-are-missing)

This 
```
  <Import Project="..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props" Condition="Exists('..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props')" />
  <Import Project="..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props" Condition="Exists('..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props')" />

   <Reference Include="Autofac, Version=3.5.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da, processorArchitecture=MSIL">
      <HintPath>..\packages\Autofac.3.5.0\lib\net40\Autofac.dll</HintPath>
      <Private>True</Private>
    </Reference>
```

Became
```
  <Import Project="..\..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props" Condition="Exists('..\..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props')" />
  <Import Project="..\..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props" Condition="Exists('..\..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props')" />

   <Reference Include="Autofac, Version=3.5.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da, processorArchitecture=MSIL">
      <HintPath>..\..\packages\Autofac.3.5.0\lib\net40\Autofac.dll</HintPath>
      <Private>True</Private>
    </Reference>
```

