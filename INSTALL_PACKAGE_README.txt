Nuget => recherche => ModernUI.WPF => installer

puis, app.xaml, ajouter dans la balise application:

<Application.Resources>
<ResourceDictionary>
<ResourceDictionary.MergedDictionaries>
  <ResourceDictionary Source="/FirstFloor.ModernUI;component/Assets/ModernUI.xaml" />
  <ResourceDictionary Source="/FirstFloor.ModernUI;component/Assets/ModernUI.Light.xaml"/>
</ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
</Application.Resources>
