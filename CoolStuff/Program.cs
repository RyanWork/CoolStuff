using System;

namespace CoolStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayIndexes();
            // Nested();

            var order = new CustomerOrder
            {
                State = "WA",
                IsVipMember = false
            };
            Console.WriteLine(order.DeliveryCostIf());
            Console.WriteLine(order.DeliveryCostSwitch());
            Console.WriteLine(order.DeliveryCostPatternMatching());
        }

        public static void ArrayIndexes()
        {
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in array[3..^3])
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(array[^1]);
        }

        public static void Nested()
        {
            Console.WriteLine(NestedFunction() + 10);
            static int NestedFunction()
            {
                return 1;
            }
        }

        class CustomerOrder
        {
            public string State { get; set; }
            public bool IsVipMember { get; set; }
            // etc.

            public decimal DeliveryCostIf()
            {
                decimal deliveryCost;
                if (this.State == "WA" && this.IsVipMember)
                {
                    deliveryCost = 0M;
                }
                else if (this.State == "WA" && !this.IsVipMember)
                {
                    deliveryCost = 2.3M;
                }
                else if (this.State == "NT" && !this.IsVipMember)
                {
                    deliveryCost = 4.1M;
                }
                else
                {
                    deliveryCost = 5M;
                }

                return deliveryCost;
            }

            public decimal DeliveryCostSwitch()
            {
                decimal deliveryCost;
                switch (this.State, this.IsVipMember)
                {
                    case ("WA", true):
                        deliveryCost = 0M;
                            break;
                    case ("WA", false):
                        deliveryCost = 2.3M;
                        break;
                    case ("NT", false):
                        deliveryCost = 4.1M;
                        break;
                    default:
                        deliveryCost = 5M;
                        break;
                }

                return deliveryCost;
            }

            public decimal DeliveryCostPatternMatching()
            {
                return this switch
                {
                    { State: "WA", IsVipMember: true } => 0M,
                    { State: "WA", IsVipMember: false } => 2.3M,
                    { State: "NT", IsVipMember: false } => 4.1M,
                    _ => 5M
                };
            }
        }
    }
}
