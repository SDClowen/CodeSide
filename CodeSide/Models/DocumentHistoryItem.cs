namespace CodeSide.Models
{
    public class DocumentHistoryItem
    {
        public bool ActiveOnTab;
        public string FilePath;

        public override string ToString()
        {
            return FilePath;
        }
    }
}
