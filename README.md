# Creating a Book Library App with .NET MAUI ListView (SfListView)

Creating a Book Library App with .NET MAUI ListView: Managing Collections Seamlessly

## Sample

```xaml
<ContentPage.Behaviors>
    <local:ListViewSearchBehavior />
</ContentPage.Behaviors>

    <Grid ColumnDefinitions="*,40">
        <SearchBar x:Name="searchBar" Grid.Column="0" />
        <Label
            Grid.Column="1"
            FontFamily="MauiSampleFontIcon"
            FontSize="Medium"
            HorizontalOptions="Center"
            Text="&#xe754;"
            TextColor="{StaticResource Primary}"
            VerticalOptions="Center">
            <Label.GestureRecognizers>
                <TapGestureRecognizer Command="{Binding CreateBookCommand}" />
            </Label.GestureRecognizers>
        </Label>
    </Grid>

    <syncfusion:SfListView
        x:Name="listView"
        Grid.Row="1"
        AutoFitMode="Height"
        ItemSize="200"
        ItemsSource="{Binding Books}"
        TapCommand="{Binding TapCommand}">
        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                <Grid
                    Margin="0"
                    Padding="8,12,8,0"
                    ColumnSpacing="0"
                    RowSpacing="0">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="1" />
                    </Grid.RowDefinitions>
                    <Grid Padding="0,0,8,10" RowSpacing="0">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Image
                            Grid.Row="0"
                            Grid.Column="0"
                            HeightRequest="100"
                            HorizontalOptions="Start"
                            Source="{Binding Image}"
                            VerticalOptions="Start"
                            WidthRequest="90" />
                        <Grid
                            Grid.Row="0"
                            Grid.Column="1"
                            RowDefinitions="Auto,Auto,Auto"
                            RowSpacing="5">
                            <Label
                                FontAttributes="Bold"
                                FontSize="16"
                                Text="{Binding Name}"
                                TextColor="#474747" />
                            <Label
                                Grid.Row="1"
                                FontSize="14"
                                Opacity=" 0.67"
                                Text="{Binding Author}"
                                TextColor="#474747" />
                            <Label
                                Grid.Row="2"
                                CharacterSpacing="0.1"
                                FontSize="13"
                                LineBreakMode="WordWrap"
                                Opacity=" 0.54"
                                Text="{Binding Description}"
                                TextColor="#474747" />
                        </Grid>
                    </Grid>
                    <BoxView
                        Grid.Row="1"
                        Margin="5,0,0,0"
                        BackgroundColor="#CECECE"
                        HeightRequest="1"
                        Opacity="0.75" />
                </Grid>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>
    </syncfusion:SfListView>
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
