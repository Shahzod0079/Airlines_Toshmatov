namespace Airlines
{
    class TicketClass
    {

        public string price { get; set; }

        public string from { get; set; }

        public string to { get; set; }

        public string time_start { get; set; }

        public string time_way { get; set; }

        public TicketClass(string from, string to, string price, string time_start, string time_way)
        {
            this.from = from;
            this.to = to;
            this.price = price;
            this.time_start = time_start;
            this.time_way = time_way;
        }
    }
}