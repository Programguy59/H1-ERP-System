using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;


    public class MusicScreen : Screen
    {
        public override string Title { get; set; } = "Music"; 
        protected override void Draw()
        {
            var songArray = Directory.GetFiles("../../../music");
            
            TechCoolUtils.Clear(this);

            var listPage = new ListPage<MusicScreenList>();

            listPage.AddColumn("Song", "Song");

            foreach (var song in songArray)
            {
                listPage.Add(new MusicScreenList(song.Substring(15).Split(".", 2)[0]));
            }

        string fileName = listPage.Select().Song;
        string selected = $@"../../../music/{fileName}.wav";
             
             Music.PlaySound(selected, true);
            
            Display(new Menu.MenuScreen());
            
        }
    }
