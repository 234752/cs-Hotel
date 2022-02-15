using HotelWF.zClasses;
using HotelWF.zFunctions;

namespace HotelWF
{
    public partial class HotelForm : Form
    {
        public HotelForm()
        {
            InitializeComponent();
            this.RegularRoomSwitch.Checked = true;
        }
        Hotel MainHotel = new Hotel();
        Room CurrentRoom = new Room(999, 99.99, 9);

        public void REFRESH()
        {
            RoomFunctions.displayRooms(MainHotel, RoomGrid);
            GuestFunctions.displayGuests(MainHotel, GuestGrid, CurrentRoom);

            this.GuestGrid.CurrentCell = null;

            int currentIndex = MainHotel.RoomList.IndexOf(CurrentRoom);
            this.RoomGrid.CurrentCell = this.RoomGrid.Rows[currentIndex].Cells[0];
            this.RoomGrid.Rows[currentIndex].Selected = true;
            this.ErrorLabel.Text = "";
        }

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            try
            {
                int n0 = 0;
                double a0 = 1.0;
                int g0 = 1;
                Int32.TryParse(this.addRoomNoInput.Text, out n0);
                Double.TryParse(this.addRoomAreaInput.Text, out a0);
                Int32.TryParse(this.addRoomMaxGuestsInput.Text, out g0);

                if (this.RegularRoomSwitch.Checked == true) { MainHotel.addRoom(new RegularRoom(n0, a0, g0)); }
                else if (this.OfficeRoomSwitch.Checked == true) { MainHotel.addRoom(new OfficeRoom(n0, a0, g0)); }
                else throw new Exception();

                CurrentRoom = MainHotel.RoomList.Last();
            }catch (Exception ex)
            {
                this.ErrorLabel.Text = "Cannot add this room, make sure that entered data is valid";
            }
            REFRESH();
        }

        private void addGuestButton_Click(object sender, EventArgs e)
        {
            int indexR = this.RoomGrid.CurrentCell.RowIndex;
            CurrentRoom = MainHotel.RoomList[indexR];

            double b0 = 0.0;
            string n0 = this.addGuestNameInput.Text;
            Double.TryParse(this.addGuestBalanceInput.Text, out b0);

            CurrentRoom.addGuest(new Guest(n0, b0));
            REFRESH();
        }

        private void displayGuestsButton_Click(object sender, EventArgs e)
        {
            int indexR = this.RoomGrid.CurrentCell.RowIndex;
            CurrentRoom = MainHotel.RoomList[indexR];
            REFRESH();
        }

        private void removeGuestButton_Click(object sender, EventArgs e)
        {
            int indexG = this.GuestGrid.CurrentCell.RowIndex;
            CurrentRoom.Guests.RemoveAt(indexG);
            REFRESH();
        }

        private void RoomGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexR = this.RoomGrid.CurrentCell.RowIndex;
            CurrentRoom = MainHotel.RoomList[indexR];
            REFRESH();
        }
    }
}