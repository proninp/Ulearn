namespace UlearnCommonConsole.Useful_acquaintances
{
    public class Solution
    {
        public static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            var dictionary = new Dictionary<string, List<string>>();
            foreach (var contact in contacts)
            {
                var key = contact.Substring(0, 2).Replace(":", "");
                if (!dictionary.ContainsKey(key))
                    dictionary.Add(key, new List<string>());
                dictionary[key].Add(contact);
            }
            return dictionary;
        }
    }
}
