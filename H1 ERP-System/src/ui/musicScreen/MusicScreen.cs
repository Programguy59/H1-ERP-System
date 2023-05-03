using H1_ERP_System.ui.customer;
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
                listPage.Add(new MusicScreenList(song));
            }

             var selected =listPage.Select();
             
             Music.PlaySound(selected.Song, true);
            
            Display(new Menu.MenuScreen());
            
        }
    }
