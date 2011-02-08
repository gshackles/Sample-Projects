using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using DatabaseDemo.Models;

namespace DatabaseDemo
{
    public class NoteListAdapter : BaseAdapter
    {
        private IEnumerable<Note> _notes;
        private Activity _context;

        public NoteListAdapter(Activity context, IEnumerable<Note> notes)
        {
            _context = context;
            _notes = notes;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = (convertView
                            ?? _context.LayoutInflater.Inflate(
                                    Resource.Layout.NoteListItem, parent, false)
                        ) as LinearLayout;
            var note = _notes.ElementAt(position);

            view.FindViewById<TextView>(Resource.Id.Title).Text = note.Title;

            return view;
        }

        public override int Count
        {
            get { return _notes.Count(); }
        }

        public Note GetNote(int position)
        {
            return _notes.ElementAt(position);
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}