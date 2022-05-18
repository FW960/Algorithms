using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphComponents;

namespace Task
{
    public static class Test
    {
        public static void Run()
        {
            var pskov = new Node<string, int> { Value = "Pskov"};

            var moscow = pskov.AddNode(732, "Moscow");

            var stPetersburg = pskov.AddNode(354, "ST.Petersburg"); stPetersburg.AddNode(706, moscow);

            var ryazan = moscow.AddNode(199, "Ryazan");

            var smolensk = ryazan.AddNode(107, "Smolensk");

            smolensk.AddNode(464, pskov); smolensk.AddNode(395, moscow);

            pskov.BFSEnum();

            pskov.DFSEnum();

            var findPskov = stPetersburg.tryFindDFS("Pskov");

            var findSPB = pskov.tryFindBFS("ST.Petersburg");

            bool successful = findPskov.DelEdge(354);

            moscow.AddNode(706, stPetersburg);

            moscow.AddNode(186, new Node<string, int> { Value = "Vladimir" });
        }
    }
}
