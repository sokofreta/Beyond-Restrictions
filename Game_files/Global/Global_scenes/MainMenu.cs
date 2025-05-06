using Godot;
using System;

public partial class MainMenu : Control
{
	Button play_button , Setting_button , Quit_button;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		play_button = (Button)GetNode("Buttons/Play_button");
		play_button.Pressed += SelectChapter;

		Setting_button = (Button)GetNode("Buttons/Settings_button") ;
		Setting_button.Pressed += OpenSettings;

		Quit_button = (Button)GetNode("Buttons/Quit_button") ;
		Quit_button.Pressed += Quit;
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SelectChapter(){
		GetTree().ChangeSceneToFile("res://Organized_files/Global/Global_scenes/chapetrs.tscn");
	}

	public void OpenSettings(){
		GetTree().ChangeSceneToFile("res://Organized_files/Global/Global_scenes/settings.tscn");
	}
	public void Quit(){
		GetTree().Quit();
	}
}

