using System;
using System.Collections.Generic;
using System.Linq;

namespace ScribemaniaAPI.Starters
{
    public static class EnglishStarters
    {
        static List<string> adjectives = new List<string>
        {
            "The absent-minded", "The alert", "The amazed", "The ancient", "The astute", "The attractive", "The awkward",
            "The bewildered", "The boring", "The brilliant", "The clean", "The cool", "The crazy", "The clumsy", "The confused",
            "The cowardly", "The crying", "The cunning", "The cute", "The deaf", "The dirty", "The drowsy", "The exhausted",
            "The first", "The former", "The funny", "The friendly", "The gentle", "The greedy", "The happy", "The hard-working",
            "The hilarious", "The horrified", "The huge", "The hungry", "The ingenious", "The kind", "The laughing", "The last",
            "The mean", "The motherly", "The mysterious", "The nervous", "The narrow minded", "The new", "The newbie",
            "The obsessed", "The outrageous", "The old", "The playful", "The poor", "The retired", "The rich", "The rookie",
            "The sadistic", "The scary", "The screaming", "The sleepy", "The slimy", "The slow", "The sly", "The sloppy",
            "The smart", "The smiling", "The tipsy", "The timid", "The tiny", "The tired", "The unhappy", "The veteran",
            "The whacky", "The youthful"
        };

        static List<string> subjects = new List<string>
        {
            "accountant", "admiral", "ant trainer", "analyst", "butterfly breeder", "bank teller", "astronaut",
            "arrow sharpener", "author", "wedding coordinator", "baseball card salesman", "baseball coach", "basketball player",
            "Olympic gymnast", "jungle guide", "award winning gardener", "bagel baker", "banker", "butcher", "butler", "captain",
            "comic book collector", "cow photographer", "toy designer", "runway model", "poker champion", "trivia whiz",
            "airline hostess", "antique dealer", "apple picker", "artist", "baby", "bagel baker", "ballet dancer", "bee keeper",
            "bird watcher", "book designer", "bounty hunter", "bowler", "boxer", "candle maker", "carpenter", "cartoonist", "cat owner",
            "caterer", "cashier", "checkers champion", "chef", "chess master", "choreographer", "chicken plucker", "coin collector",
            "cobbler", "comedian", "computer programmer", "cook", "college president", "coroner", "crayon collector", "dancer", "dentist",
            "detective", "diamond cutter", "dietitian", "doctor", "dog handler", "dog walker", "skydiver", "doll maker", "counterfeiter",
            "cowboy", "crossword puzzle maker", "stockbroker", "doorman", "draftsman", "dress designer", "drifter", "driver", "drummer",
            "editor", "elevator operator", "exterminator", "executioner", "fingerprint expert", "finger painting master", "explorer",
            "firefighter", "florist", "forger", "frog breeder", "furniture refinisher", "gambler", "gardener", "general", "glass blower",
            "golfer", "goalie", "grave digger", "haircutter", "helicopter pilot", "handwriting expert", "hotel manager", "house painter",
            "impersonator", "IRS agent", "intern", "ink tester", "janitor", "jewel thief", "jockey", "kindergartener", "landlord", "lawyer",
            "leader", "librarian", "lion tamer", "loan officer", "magician", "manager", "manicurist", "mathematician", "miner",
            "mountain climber", "mortician", "mouse rater", "movie critic", "movie star", "musician", "newspaper reporter", "old man",
            "nanny", "newlywed", "opera diva", "operator", "optometrist", "penmanship champion", "photographer",
            "piano tuner", "pickle maker", "pigeon trainer", "pilot", "pizza maker", "pirate", "plumber", "police officer", "pastor",
            "priest", "principal", "printer", "professor", "gemologist", "hiker", "mountain climber", "union leader",
            "social media expert", "Zen master", "karate expert", "quilter", "square dance caller", "prospector", "rabbi",
            "radio announcer", "rat salesman", "reporter", "rookie", "saddle maker", "scientist", "silverware polisher",
            "race car driver", "scout leader", "secret agent", "sharpshooter", "singer", "sleep walker", "soldier", "sailor", "spy",
            "stamp collector", "student teacher", "stutterer", "substitute teacher", "stock broker", "rival", "sweeper",
            "candle stick maker", "tailor", "taxidermist", "teacher", "turtle trainer", "tutor", "train conductor", "travel agent",
            "truck driver", "undercover shopper", "undertaker", "used car salesman", "used typewriter salesman", "used paint salesman",
            "veterinarian", "ventriloquist", "violinist", "waiter", "waltz historian", "watch maker", "window washer", "wizard", "writer",
            "football player", "baseball star", "checkers champion", "cement mixer", "miner", "hat tester", "sock inspector",
            "violinist", "zoo keeper"
        };

        static List<string> actions = new List<string>
        {
            "alerted the police inside", "added an orchid in", "baked an apple pie in", "boiled a potato in",
            "built a house in", "canceled the check in", "carved the profile in", "caught a fish above", "carved a turkey in",
            "carved a statue within", "cleaned the keyboard in", "climbed the wall in", "collected the water from",
            "composed a song in", "crawled into", "created a Twitter account in", "cut the grass near", "crawled under the table in",
            "destroyed the evidence in", "deleted the email near", "dialed the cell phone in", "did bypass surgery in",
            "duplicated a map in", "erased the message in", "finished the audit in", "flew a helicopter near", "flew over",
            "hid the key in", "jumped near", "made a video in", "missed a basket in", "opened the safe in", "painted a portrait in",
            "produced a movie in", "ran as fast as possible to", "recited a poem in", "repaired the bomb in", "robbed a bank in",
            "rode the bicycle into", "sang a song in", "sat on the rocking chair in", "scribbled a note in", "served breakfast in",
            "smiled at the guard in", "soaked the left shoe in", "sold a green mouse in", "started the operation in",
            "started to scream in", "startled a burglar in", "struck the match in", "struck out near",
            "struggled with the checkbook in", "threw a feather within", "told a joke in", "parked a bus near",
            "polished the table near", "recorded a conversation in", "spoiled the joke near", "dropped the letter in",
            "found the top secret document in", "took pictures near", "trimmed the bush near", "visited a cemetery near",
            "washed a car near", "watered the lawn close to", "wiped off the fingerprint in", "wrote a song near", "wrote a story in",
            "wrote a play in", "wrote a poem in"
        };

        static List<string> objects = new List<string>
        {
            "a broken elevator", "a broken refrigerator", "the comic book store", "a closed gas station",
            "the clown store", "a dark alley", "a department store", "a lonely bus stop", "a neat closet", "a narrow tunnel",
            "a secret passageway", "a warehouse", "an attic", "a darkened room", "an abandoned toy store", "Fort Knox", "the backyard",
            "the ballroom", "the ball field", "the basement", "the car", "the dancing studio", "the dark corner", "the airport",
            "the heliport", "the bus terminal", "the dilapidated zoo", "the foggy block", "the diner", "the garage",
            "the gas station", "the ghost town", "the barn", "the house", "the hidden room", "the huge truck", "the junkyard",
            "the kitchen", "the lonely diner", "the movie theater", "the noisy cafeteria", "the pencil museum", "the Pentagon",
            "the playground", "the prison", "the scorching desert", "the ship", "the school", "the skyscraper", "the small town",
            "the space ship", "the Statue of Liberty", "the store", "the submarine", "the supermarket", "the sunken ship", "the taxi",
            "the tent", "the underground cave", "the vault", "the volcano", "the White House", "the jewelry store", "the witch house"
        };

        static List<string> preps = new List<string>
        {
            "for the actor.", "for the architect.", "for the captain.", "for the CEO.", "for the doctor.",
            "for the dentist.", "for the deadly frog.", "for the electrician.", "for the FBI.", "for the grandmother.",
            "for the hunter.", "for the killer bees.", "for the lawyer.", "for the mystery writer.", "for the nurse.",
            "for the retired donut baker.", "for the old lady.", "for the poor family.", "for the puppies.", "for the Russians.",
            "for the Senator.", "for the surgeon.", "for the teacher.", "for the team.", "just for fun.", "to answer the challenge.",
            "to avoid the argument.", "to clear the record.", "to complete the coverup.", "to confuse the investigator.",
            "to cover things up.", "to visit a nephew.", "to create a diversion.", "to conduct the dangerous experiment.",
            "to confuse the investigator.", "to corner the monster.", "to delay the vote.", "to discover the dark secret.",
            "to dispel the rumor.", "to eliminate the competition.", "to elude the police.", "to end the feud.",
            "to find the rare stamp.", "to find the missing horse.", "to find the treasure.", "to quiet the angry mob.",
            "to rebuild the cave.", "to solve the mystery.", "to pay the debt.", "to prevent the accident.",
            "to prevent the bloodshed.", "to prevent the fight.", "to run a marathon.", "to sail around the world.",
            "to uncover the plan.", "to unearth the real reason.", "to visit the gutted building.", "to walk across the bridge.",
            "to win the bet.", "to win the contest.", "to wake up the President."
        };

        static T randomListItem<T>(List<T> list)
        {
            var randomGenerator = new Random();
            return list.ElementAt(randomGenerator.Next(list.Count));
        }

        public static string Generate()
        {
            var storyParts = new List<string>();
            storyParts.Add(randomListItem(EnglishStarters.adjectives));
            storyParts.Add(randomListItem(EnglishStarters.subjects));
            storyParts.Add(randomListItem(EnglishStarters.actions));
            storyParts.Add(randomListItem(EnglishStarters.objects));
            storyParts.Add(randomListItem(EnglishStarters.preps));
            return String.Join(" ", storyParts);
        }
    }
}