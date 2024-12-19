using System;

namespace FurnitureApp
{
    internal class EditUserForm
    {
        private int userId;
        private string role;

        public EditUserForm(int userId, string role)
        {
            this.userId = userId;
            this.role = role;
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}