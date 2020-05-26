using System;

namespace Labs2_2_var4
{
    class CosmicHierarchy
    {
        static void Main(String[] args)
        {
            Earth earth = new Earth(true);
            earth.rotatePeriod = 365;
            earth.ShowObjectInfo();

            Mars mars = new Mars();
            mars.IsDustStorm = false;
            mars.WorkStations = 1;
            mars.rotatePeriod = 779;
            mars.objectMass = 0.1;
            mars.objectRadius = 3389;
            mars.satellites = 2;
            Console.Write("\nThere is life on Mars:" + mars.lifeable(227));
            mars.ShowObjectInfo();
            mars.helloCuriosity();
            
            Sun sun = new Sun();
            sun.objectRadius = 6955100;
            sun.Spots = 112;
            sun.ShowObjectInfo();
            sun.checkActive();
            sun.doCollapse(15);

            Star star = new Star();
            star.ShowObjectInfo();
            Star betelheise = new Star(32000000, "red overgiant");
            betelheise.Name = "Betelheise";
            betelheise.objectMass = 5660000;
            betelheise.objectRadius = 700000000;
            betelheise.ShowObjectInfo();
            betelheise.doCollapse(600000);
                        
            Planet planet = new Planet(true);
            planet.ShowObjectInfo();
            Planet jupiter = new Planet(317, 4332, 79);
            jupiter.Name = "Jupiter";
            jupiter.starDistance = 778;
            jupiter.objectRadius = 69911;
            jupiter.ShowObjectInfo();
            jupiter.countVolume();
            
            StarSystem.ShowStarSystemInfo();
        }
    }
}