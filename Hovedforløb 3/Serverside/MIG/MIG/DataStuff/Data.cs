﻿using MIG.Song;
using System.Collections.Generic;

namespace MIG.DataStuff
{
    public abstract class Data : Names
    {
        /// <summary>
        /// Playlist of genres from Spotify
        /// </summary>
        public static Category Playlist { get;  } = new Category("Spotify Playlist")
        {
            SubCategories = new List<Category>()
            {
                new Category("Everything Mixed")
                {
                    SubCategories = new List<Category>()
                    {
                        new Category("Lofi HipHop")
                        {
                            Genres = new List<Genre>()
                            {
                                #region Calm Lofi
                                new Genre
                                (
                                    Genres.CalmLofi,
                                    70, 100,
                                    new Drums(KickOptions.Lofi, ClapOptions.Main, HihatOptions.Lofi, OpenHatOptions.Acoustic, SnareOptions.Lofi),
                                    new Synths(false, false, false, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                                #region FeelsDepressedMan
                                new Genre
                                (
                                    Genres.FeelsDepressedMan,
                                    70, 100,
                                    new Drums(KickOptions.Lofi, ClapOptions.Main, HihatOptions.Lofi, OpenHatOptions.Acoustic, SnareOptions.Lofi),
                                    new Synths(false, false, false, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                            }
                        },
                        new Category("Rock Metal, something with guitar")
                        {
                            Genres = new List<Genre>()
                            {
                                #region Emo
                                new Genre
                                (
                                    Genres.Emo,
                                    80, 180,
                                    new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                    new Synths(true, false, false, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                                #region Old
                                new Genre
                                (
                                    Genres.Old,
                                    80, 180,
                                    new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                    new Synths(false, false, false, false),
                                    new Instruments(false, true, false, false)
                                ),
                                #endregion
                                #region Goth
                                new Genre
                                (
                                    Genres.Goth,
                                    80, 180,
                                    new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                    new Synths(true, false, false, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                                #region Metal I Think
                                new Genre
                                (
                                    Genres.MetalIThink,
                                    80, 180,
                                    new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                    new Synths(true, false, false, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                                #region RockIThink
                                new Genre
                                (
                                    Genres.RockIThink,
                                    80, 180,
                                    new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                    new Synths(true, false, false, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                                #region WannabeMetal
                                new Genre
                                (
                                    Genres.WannabeMetal,
                                    80, 180,
                                    new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                    new Synths(true, false, true, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                                #region Pop-Rock
                                new Genre
                                (
                                    Genres.PopRock,
                                    80, 180,
                                    new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                    new Synths(true, false, false, false),
                                    new Instruments(true, true, false, true)
                                ),
                                #endregion
                            }
                        },
                        new Category("Trap/Rap/Hip Hop")
                        {
                            Genres = new List<Genre>()
                            {
                                #region Da Feels
                                new Genre
                                (
                                    Genres.DaFeels,
                                    135, 145,
                                    new Drums(KickOptions.Punchy, ClapOptions.Tight, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.Trap),
                                    new Synths(true, false, false, true),
                                    new Instruments(true, false, false, true)
                                ),
                                #endregion
                                #region FeelsCoolMan
                                new Genre
                                (
                                    Genres.FeelsCoolMan,
                                    135, 145,
                                    new Drums(KickOptions.Punchy, ClapOptions.Tight, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.Trap),
                                    new Synths(true, false, false, true),
                                    new Instruments(true, false, false, true)
                                ),
                                #endregion
                                #region Da Vibe
                                new Genre
                                (
                                    Genres.DaVibe,
                                    135, 145,
                                    new Drums(KickOptions.Punchy, ClapOptions.Tight, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.Trap),
                                    new Synths(true, false, false, true),
                                    new Instruments(true, false, false, true)
                                )
                                #endregion
                            }
                        }
                    },
                        Genres = new List<Genre>()
                        {
                            #region Acoustic
                            new Genre
                            (
                                Genres.Acoustic,
                                80, 130,
                                new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                new Synths(false, false, false, false),
                                new Instruments(true, true, false, true)
                            ),
                            #endregion
                            #region Country
                            new Genre
                            (
                                Genres.Country,
                                70, 120,
                                new Drums(KickOptions.Acoustic, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.Acoustic),
                                new Synths(false, false, false, false),
                                new Instruments(true, true, false, false)
                            ),
                            #endregion
                        }
                    },
                new Category("EDM")
                    {
                        SubCategories = new List<Category>()
                        {
                            new Category("Big Room")
                            {
                                SubCategories = new List<Category>()
                                {
                                    new Category("Bounce")
                                    {
                                        Genres = new List<Genre>()
                                        {
                                            #region Bootleg
                                            new Genre
                                            (
                                                Genres.Bootleg,
                                                128, 140,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.House),
                                                new Synths(true, false, true, true),
                                                new Instruments(true, true, true, true)
                                            ),
                                            #endregion
                                            #region Bounce
                                            new Genre
                                            (
                                                Genres.Bounce,
                                                125, 175,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.House),
                                                new Synths(true, false, true, true),
                                                new Instruments(true, true, true, true)
                                            ),
                                            #endregion
                                            #region Melbourne Bounce
                                            new Genre
                                            (
                                                Genres.MelbourneBounce,
                                                126, 128,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.House),
                                                new Synths(true, false, true, true),
                                                new Instruments(true, true, true, true)
                                            )
	                                        #endregion
                                        }
                                    }
                                },
                                Genres = new List<Genre>()
                                {
                                    #region Big Room
                                    new Genre
                                    (
                                        Genres.BigRoom,
                                        126, 150,
                                        new Drums(KickOptions.Punchy, ClapOptions.Huge, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, true, true)
                                    ),
                                    #endregion
                                    #region Spinnin' Records
                                    new Genre
                                    (
                                        Genres.SpinninRecords,
                                        125, 135,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, true, true)
                                    )
	                                #endregion
                                }
                            },
                            new Category("Drum and Stuff")
                            {
                                Genres = new List<Genre>()
                                {
                                    #region Drumstep
                                    new Genre
                                    (
                                        Genres.Drumstep,
                                        110, 175,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, true, true)
                                    ),
                                    #endregion
                                    #region Drum n Bass
                                    new Genre
                                    (
                                        Genres.DnB,
                                        160, 180,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, true, true)
                                    )
                                    #endregion
                                }
                            },
                            new Category("Dubstep")
                            {
                                Genres = new List<Genre>()
                                {
                                    #region Dubstep
                                    new Genre
                                    (
                                        Genres.Dubstep,
                                        125, 174,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, true, true)
                                    ),
                                    #endregion
                                    #region Melodic Dubstep
                                    new Genre
                                    (
                                        Genres.MelodicDubstep,
                                        105, 174,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, true, true)
                                    ),
	                                #endregion
                                }
                            },
                            new Category("Future")
                            {
                                Genres = new List<Genre>()
                                {
                                    #region Future Bass
                                    new Genre
                                    (
                                        Genres.FutureBass,
                                        140, 170,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.FutureBass),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, false, true)
                                    ),
                                    #endregion
                                    #region Future Funk
                                    new Genre
                                    (
                                        Genres.FutureFunk,
                                        90, 132,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.FutureBass),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, false, true)
                                    ),
                                    #endregion
                                    #region Future House
                                    new Genre
                                    (
                                        Genres.FutureHouse,
                                        120, 160,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.FutureBass),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, false, true)
                                    ),
                                    #endregion
                                    #region Future Bounce
                                    new Genre
                                    (
                                        Genres.FutureBounce,
                                        125, 128,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.FutureBass),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, false, true)
                                    )
	                                #endregion
                                }
                            },
                            new Category("Electro")
                            {
                                Genres = new List<Genre>()
                                {
                                    #region Electro
                                    new Genre
                                    (
                                        Genres.Electro,
                                        100, 130,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, false)
                                    ),
                                    #endregion
                                    #region Electro Swing
                                    new Genre
                                    (
                                        Genres.ElectroSwing,
                                        90, 128,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, true)
                                    ),
	                                #endregion
                                }
                            },
                            new Category("General")
                            {
                                Genres = new List<Genre>()
                                {
                                    #region General EDM
                                    new Genre
                                    (
                                        Genres.GeneralEDM,
                                        110, 140,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, true, true)
                                    ),
                                    #endregion
                                    #region EDM Trap
                                    new Genre
                                    (
                                        Genres.EDMTrap,
                                        95, 170,
                                        new Drums(KickOptions.Punchy, ClapOptions.Tight, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.Trap),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, false, true, true)
                                    ),
                                    #endregion
                                    #region Electrio
                                    new Genre
                                    (
                                        Genres.Electrio,
                                        100, 175,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, true, true)
                                    ),
                                    #endregion
                                }
                            },
                            new Category("Hype")
                            {
                                SubCategories = new List<Category>()
                                {
                                    new Category("Classic")
                                    {
                                        Genres = new List<Genre>()
                                        {
                                            #region Hands Up
                                            new Genre
                                            (
                                                Genres.HandsUp,
                                                128, 170,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            ),
                                            #endregion
                                            #region Eurodance
                                            new Genre
                                            (
                                                Genres.EuroDance,
                                                126, 155,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, true, true)
                                            ),
                                            #endregion
                                        }
                                    },
                                    new Category("High BPM")
                                    {
                                        SubCategories = new List<Category>()
                                        {
                                            new Category("Hardstyle")
                                            {
                                                SubCategories = new List<Category>()
                                                {
                                                    new Category("Euphoric")
                                                    {
                                                        Genres = new List<Genre>()
                                                        {
                                                            #region Dreamy
                                                            new Genre
                                                            (
                                                                Genres.Dreamy,
                                                                150, 170,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, false, true)
                                                            ),
	                                                        #endregion
                                                            #region Euphoric
                                                            new Genre
                                                            (
                                                                Genres.Euphoric,
                                                                150, 170,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, true, true)
                                                            ),
                                                            #endregion
                                                            #region Raw Euphoric
                                                            new Genre
                                                            (
                                                                Genres.RawEuphoric,
                                                                150, 170,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, true, true)
                                                            ),
                                                            #endregion
                                                            #region Nasty Euphoric
                                                            new Genre
                                                            (
                                                                Genres.RawEuphoric,
                                                                150, 170,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, true, true)
                                                            ),
                                                            #endregion 
                                                        }
                                                    },
                                                    new Category("Rawstyle")
                                                    {
                                                        Genres = new List<Genre>()
                                                        {
                                                            #region Rawstyle
                                                            new Genre
                                                            (
                                                                Genres.Rawstyle,
                                                                160, 190,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, true, true)
                                                            ),
                                                            #endregion
                                                            #region Psychedelic Rawstyle
                                                            new Genre
                                                            (
                                                                Genres.PsychedelicRawstyle,
                                                                160, 190,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, true, true)
                                                            ),
                                                            #endregion 
                                                            #region Hardcore
                                                            new Genre
                                                            (
                                                                Genres.Hardcore,
                                                                180, 220,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, true, true)
                                                            ),
                                                            #endregion
                                                            #region Uptempo
                                                            new Genre
                                                            (
                                                                Genres.Uptempo,
                                                                200, 250,
                                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                                new Synths(true, true, true, true),
                                                                new Instruments(true, true, true, true)
                                                            ),
                                                            #endregion
                                                        }
                                                    }
                                                },
                                                Genres = new List<Genre>()
                                                {
                                                    #region Frenchcore
                                                    new Genre
                                                    (
                                                        Genres.Frenchcore,
                                                        190, 220,
                                                        new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                        new Synths(true, true, true, true),
                                                        new Instruments(true, true, true, true)
                                                    )
                                                    #endregion 
                                                }
                                            }
                                        },
                                        Genres = new List<Genre>()
                                        {
                                            #region Russian Hard Bass
                                            new Genre
                                            (
                                                Genres.HardBass,
                                                150, 180,
                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, true, true)
                                            ),
                                            #endregion
                                            #region Speedcore
                                            new Genre
                                            (
                                                Genres.Speedcore,
                                                220, 300,
                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, true, true)
                                            ),
                                            #endregion
                                            #region Happy Hardcore
                                            new Genre
                                            (
                                                Genres.HappyHardcore,
                                                150, 180,
                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.Clubby),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, true, true)
                                            )
                                            #endregion
                                        }
                                    },
                                    new Category("Trance")
                                    {
                                        Genres = new List<Genre>()
                                        {
                                            #region Trance
                                            new Genre
                                            (
                                                Genres.Trance,
                                                135, 150,
                                                new Drums(KickOptions.Clubby, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Clubby, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, false, false, true)
                                            ),
                                            #endregion
                                            #region Psytrance
                                            new Genre
                                            (
                                                Genres.Psytrance,
                                                138, 145,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Clubby, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, false, false, true)
                                            )
                                            #endregion
                                        }
                                    }
                                }
                            },
                            new Category("House")
                            {
                                Genres = new List<Genre>()
                                {
                                    #region Aimbottz House
                                    new Genre
                                    (
                                        Genres.AimbottzHouse,
                                        120, 130,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, true)
                                    ),
                                    #endregion
                                    #region Deep House
                                    new Genre
                                    (
                                        Genres.DeepHouse,
                                        120, 130,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, true)
                                    ),
                                    #endregion
                                    #region House
                                    new Genre
                                    (
                                        Genres.House,
                                        120, 130,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, true, true)
                                    ),
                                    #endregion
                                    #region Melodic House
                                    new Genre
                                    (
                                        Genres.MelodicHouse,
                                        120, 140,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, true)
                                    ),
                                    #endregion
                                    #region Tropical House
                                    new Genre
                                    (
                                        Genres.TropicalHouse,
                                        100, 128,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, true)
                                    ),
                                    #endregion
                                },
                                SubCategories = new List<Category>()
                                {
                                    new Category("Progressive House")
                                    {
                                        Genres = new List<Genre>()
                                        {
                                            #region Progressive House
                                            new Genre
                                            (
                                                Genres.ProgressiveHouse,
                                                120, 135,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            ),
                                            #endregion
                                            #region Progressive Dream
                                            new Genre
                                            (
                                                Genres.ProgressiveDream,
                                                110, 130,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            ),
                                            #endregion
                                            #region Progressive Pop
                                            new Genre
                                            (
                                                Genres.ProgressivePop,
                                                125, 130,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            ),
                                            #endregion
                                            #region NCS Style
                                            new Genre
                                            (
                                                Genres.NCS,
                                                125, 130,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            )
                                            #endregion
                                        }
                                    },
                                    new Category("Electro-House")
                                    {
                                        Genres = new List<Genre>()
                                        {
                                            #region Electro-House
                                            new Genre
                                            (
                                                Genres.ElectroHouse,
                                                90, 175,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            ),
                                            #endregion
                                            #region Taking Electro Literal
                                            new Genre
                                            (
                                                Genres.TakingElectroLiteral,
                                                128, 130,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            ),
                                            #endregion
                                            #region Dudu dudu
                                            new Genre
                                            (
                                                Genres.Dudududu,
                                                100, 130,
                                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.House, SnareOptions.House),
                                                new Synths(true, true, true, true),
                                                new Instruments(true, true, false, true)
                                            )
                                            #endregion
                                        }
                                    }
                                }
                            },
                            new Category("Old School")
                            {
                                Genres = new List<Genre>()
                                {
                                    #region Downtempo
                                    new Genre
                                    (
                                        Genres.Downtempo,
                                        100, 130,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Tick, OpenHatOptions.Acoustic, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, true)
                                    ),
                                    #endregion
                                    #region Synthwave
                                    new Genre
                                    (
                                        Genres.Synthwave,
                                        90, 133,
                                        new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.Acoustic, SnareOptions.House),
                                        new Synths(true, true, true, true),
                                        new Instruments(true, true, false, true)
                                    ),
                                    #endregion
                                }
                            },
                        },
                        Genres = new List<Genre>()
                        {
                            #region Pop
                            new Genre
                            (
                                Genres.Pop,
                                75, 140,
                                new Drums(KickOptions.Punchy, ClapOptions.Main, HihatOptions.Acoustic, OpenHatOptions.House, SnareOptions.House),
                                new Synths(true, false, true, true),
                                new Instruments(true, true, true, true)
                            ),
                            #endregion
                        }
                    }
            }
        };

        /// <summary>
        /// Collects all genres
        /// </summary>
        /// <returns>All Genres as Array</returns>
        public static Dictionary<string, Genre> GetGenres() => GetGenres(Playlist);
        public static Dictionary<string, Genre> GetGenres(Category category)
        {
            var result = new Dictionary<string, Genre>();
            if (category.Genres != null)
                foreach (Genre genre in category.Genres)
                    result.Add(genre.Title, genre);
            if (category.SubCategories != null)
                foreach (Category subCategory in category.SubCategories)
                {
                    var subCategoryResult = GetGenres(subCategory);
                    foreach (KeyValuePair<string, Genre> kvp in subCategoryResult)
                        result.Add(kvp.Key, kvp.Value);
                }
            return result;
        }

        /// <summary>
        /// Defines all artists 
        /// </summary>
        /// <returns></returns>
        public static Artist[] GetArtists() => new Artist[]
            {
                new Artist("3LAU", new Track[]
                {
                    new Track("At Night (With GRABBITZ)", "3.40", Genres.FutureBounce, Genres.DeepHouse),
                    new Track("Better With You", "3.12", Genres.ProgressiveDream),
                    new Track("Escape - Original Mix", "4.35", Genres.Electro, Genres.ProgressiveHouse),
                    new Track("Everything", "3.19", Genres.ProgressiveDream),
                    new Track("Falling", "3.29", Genres.FutureBounce),
                    new Track("How You Love Me", "4.58", Genres.ProgressiveDream),
                    new Track("Touch", "3.26", Genres.ProgressiveDream)
                }, new Track[]
                {
                    new Track("Can't Forget You", "3.24", Genres.Pop),
                }),
                new Artist("Aero Chord", new Track[]
                {
                    new Track("Boundless", "3.13", Genres.EDMTrap),
                    new Track("4U", "4.04", Genres.Bounce),
                    new Track("The Sound", "3.31", Genres.EDMTrap),
                    new Track("Surface", "4.14", Genres.EDMTrap)
                }, new Track[]
                { 
                    new Track("The Munsta", "3.40", Genres.EDMTrap)
                }),
                new Artist("After Forever", new Track[]
                {
                    new Track("Discord", "4.37", Genres.Goth),
                    new Track("Energize Me", "3.11", Genres.Goth),
                    new Track("Come", "5.02", Genres.Goth),
                    new Track("Boundaries Are Open", "3.45", Genres.Goth),
                    new Track("Living Shields", "4.13", Genres.Goth),
                    new Track("Being Everyone", "3.39", Genres.Goth),
                    new Track("Only Everything - Session Version", "6.36", Genres.Goth)
                }),
                new Artist("Ahrix", new Track[]
                {
                    new Track("A New Start [Bonus Track]", "3.02", Genres.Euphoric, Genres.ProgressiveDream),
                    new Track("Carpe Deim", "3.42", Genres.Dudududu),
                    new Track("Courage", "3.22", Genres.Dudududu),
                    new Track("Daydream", "3.43", Genres.Dudududu, Genres.ProgressiveDream),
                    new Track("Dreams", "3.23", Genres.ProgressiveDream),
                    new Track("End of Time", "3.08", Genres.Dudududu),
                    new Track("Euphoria", "3.18", Genres.Dudududu),
                    new Track("Evolving", "3.24", Genres.ProgressiveDream),
                    new Track("Forgiven", "3.07", Genres.Dudududu),
                    new Track("Hope", "3.16", Genres.ProgressiveHouse),
                    new Track("Left Behind", "3.08", Genres.Dudududu),
                    new Track("Moments", "4.08", Genres.ProgressiveDream),
                    new Track("Never Alone", "3.25", Genres.Dudududu),
                    new Track("New Era", "3.36", Genres.ProgressiveDream),
                    new Track("Nova", "4.41", Genres.Dudududu),
                    new Track("The Dreamer", "3.53", Genres.ProgressiveDream),
                    new Track("Pure", "3.19", Genres.Dudududu),
                    new Track("Raising", "3.07", Genres.Dudududu),
                    new Track("Reborn", "3.41", Genres.Dudududu),
                    new Track("Relief", "3.37", Genres.Dudududu),
                    new Track("Senrenity", "3.10", Genres.Drumstep),
                    new Track("We Don't Know", "3.42", Genres.ProgressiveDream),
                }, new Track[]
                {
                    new Track("Ignite (feat. SEUNGRI)", "3.37", Genres.Dudududu)
                }),
                new Artist("Al Storm", new Track[]
                {
                    new Track("Cannibalism! - Original Mix", "4.48", Genres.HappyHardcore),
                    new Track("Crash (My Body. Your Body) - Original Mix", "4.48", Genres.HappyHardcore),
                    new Track("Crazy 'Bout Your Love", "5.11", Genres.HappyHardcore),
                    new Track("I Created A Monster! IYF & Nobody Remix", "5.10", Genres.HappyHardcore),
                    new Track("Here 3 Invade", "5.53", Genres.HappyHardcore),
                    new Track("Lose Somebody", "4.45", Genres.HappyHardcore),
                }),
                new Artist("Alan Walker", new Track[]
                {
                    new Track("All Falls Down (feat. Juliander)", Dudududu),
                    new Track("Alone", Dudududu),
                    new Track("Avem (The Aviation Theme)", Dudududu),
                    new Track("Darkside", Dudududu),
                    new Track("I Don't Wanna Go", Dudududu),
                    new Track("Lily", Dudududu),
                    new Track("Different World (feat. CORSAK)", Dudududu),
                    new Track("Fade", Dudududu),
                    new Track("Faded", Dudududu),
                    new Track("Force", Dudududu),
                    new Track("Ignite", Dudududu),
                    new Track("Sky", Dudududu),
                    new Track("Live Fast - PUBGM", Trap),
                    new Track("On My Way", TropHouse),
                    new Track("Sing Me to Sleep", Dudududu),
                    new Track("Spectre", Dudududu),
                    new Track("The Spectre", Dudududu),
                    new Track("End of Time", Dudududu),
                    new Track("Play", Dudududu)
                }, new Track[]
                {
                    new Track("Lonely Together - (feat. Rita Ora)", ProgPop),
                    new Track("Millionaire", Dudududu),
                    new Track("Play - Niya & Alan Walker Remix)", Dudududu),
                    new Track("This Is Me (From \"The Greatest Showman\")", Dudududu),
                    new Track("Stranger Things (feat. OneRepublic)", Dudududu),
                    new Track("Sheep (Alan Walker Relift)", EDMTrap, Dudududu)
                }),
                new Artist("Approaching Nirvana", new Track[]
                {
                    new Track("Sugar High", Electrio, Electro),
                    new Track("Bangers & Smashed", ProgHouse),
                    new Track("305", Dudududu)
                }),
                new Artist("Atef", new Track[]
                {
                    new Track("Abyss", Dudududu),
                    new Track("Away", Dudududu),
                    new Track("Colors", Dudududu),
                    new Track("Faith", Dudududu),
                    new Track("Journey", Dudududu),
                    new Track("Launch", ProgDream, Hardcore),
                    new Track("Promises", Dudududu),
                    new Track("Puzzle Rd. 1", Hardcore),
                    new Track("Spectrum", ProgHouse, Hardcore)
                }),
                new Artist("Avicii", new Track[]
                {
                    new Track("Lonely Together (feat. Rita Ora)", ProgPop),
                    new Track("Without You (feat. Sandro Cavazza)", ProgPop),
                    new Track("The Days", ProgPop),
                    new Track("The Nights", ProgPop),
                    new Track("I Could Be The One [Avicii vs Nicky Romero - Nicktim - Radio Edit", ProgPop),
                    new Track("Levels - Radio Edit", ProgPop),
                    new Track("Lonely Together - Acoustic", Acoustic),
                    new Track("Waiting For Love", ProgPop),
                    new Track("Taste The Feeling (Avicii Vs. Conrad Sewell)", Pop),
                    new Track("Wake Me Up - Radio Edit", ProgPop),
                    new Track("Hey Brother", ProgPop),
                    new Track("Addicted To You", ProgPop)
                }),
                new Artist("BABYMETAL", new Track[]
                {
                    new Track("Megitsune", RockMetal),
                    new Track("Gimme Chocolate!!", RockMetal),
                    new Track("Distortion", RockMetal),
                    new Track("Elevator Girl - English Version", RockMetal),
                    new Track("PA PA YA!!", RockMetal),
                    new Track("Shine", RockMetal)
                }),
                new Artist("Basshunter", new Track[]
                {
                    new Track("Don't Walk Away", EuroDance, Dudududu),
                    new Track("Home", Dudududu),
                    new Track("DotA - Radio Edit", EuroDance),
                    new Track("Now You're Gone (feat. DJ Metal Theos Bazzheadz)", EuroDance),
                    new Track("All I Ever Wanted - Radio Edit", EuroDance),
                    new Track("I Can Walk On Water", EuroDance),
                    new Track("Boten Anna - Radio edit", EuroDance),
                }),
                new Artist("Bassjackers", new Track[]
                {
                    new Track("Derp", Spinnin),
                    new Track("Savior - Radio Edit", Spinnin),
                    new Track("Wave Your Hands", Spinnin)
                }),
                new Artist("Braken", new Track[]
                {
                    new Track("Far Away", MelDubstep),
                    new Track("Frame of Mind", MelDubstep),
                    new Track("Flight", Dubstep)
                }),
                new Artist("Brian Tuey", new Track[]
                {
                    new Track("Damned", Acoustic),
                    new Track("Lullaby Of A Deadman", RockMetal),
                    new Track("The One", RockMetal),
                    new Track("Beauty Of Annihilation", RockMetal),
                    new Track("Twiligt", RockMetal),
                    new Track("115", RockMetal),
                    new Track("Undone", RockMetal)
                }),
                new Artist("Calvin Harris", new Track[]
                {
                    new Track("We'll Be Coming Back (feat. Example)", ProgPop),
                    new Track("Iron", ProgPop),
                    new Track("Drinking from the Bottle (feat. Tinie Tempah)", ProgPop),
                    new Track("Let's Go (feat. Ne-Yo)", ProgPop, ProgHouse),
                    new Track("Blame", ProgPop),
                    new Track("Under Control", ProgPop),
                    new Track("Outside", ProgPop),
                    new Track("Summer", ProgPop),
                    new Track("Together", ProgPop)
                }),
                new Artist("Cascada", new Track[]
                {
                    new Track("Every time we touch", HandsUp),
                    new Track("Like the Way I Do", Pop),
                    new Track("Counting Down The Days - Cascada Radio Edit", HandsUp),
                    new Track("Madness - DJ Gollum feat. DJ Cap Radio Edit", HandsUp)
                }),
                new Artist("Crystal Lake", new Track[]
                {
                    new Track("Chosen Ones", Hardstyle),
                    new Track("Circles", Hardstyle),
                    new Track("Follow Me", Hardstyle)
                }),
                new Artist("D-Sturb", new Track[]
                {
                    new Track("For The Night", Rawstyle),
                    new Track("Hit The Ground", Rawstyle),
                    new Track("Extortionist", Rawstyle),
                    new Track("Take On The World", Rawstyle),
                    new Track("Anything", Rawstyle),
                    new Track("Nothing Like The Oldschool", Rawstyle),
                    new Track("The Last Man Standing", Rawstyle),
                    new Track("Universe", Rawstyle),
                    new Track("No Tears", Rawstyle),
                    new Track("Hold On", Rawstyle),
                    new Track("Feel It!", Rawstyle),
                    new Track("Let The Games Begin", Rawstyle)
                }),
                new Artist("Da Tweekaz", new Track[]
                {
                    new Track("Jägermeister", Hardstyle),
                    new Track("Bring Me To Life", Hardstyle),
                    new Track("Because Of You", Rawstyle),
                    new Track("How Far I'll Go", Hardstyle),
                    new Track("Keep On Rockin'", Hardstyle),
                    new Track("Komon", Hardstyle),
                    new Track("Letting Go - Radio Version", Hardstyle),
                    new Track("Because Of You", Hardstyle),
                    new Track("Adrenaline", Hardstyle),
                    new Track("Moskau", Rawstyle),
                    new Track("Shake Ya Shimmy", Hardstyle),
                    new Track("We Made It", Hardstyle),
                    new Track("The Elite", Hardstyle),
                    new Track("Bad Habit - Radio Version", Hardstyle),
                    new Track("Take Me Away", Hardstyle),
                    new Track("Wodka - Radio Edit", Hardstyle)
                }, new Track[]
                {
                    new Track("Alone, Pt. II", Hardstyle),
                    new Track("On My Way", Hardstyle),
                    new Track("The Calling", Hardstyle),
                    new Track("We Go Up", Hardstyle)
                }),
                new Artist("Daniel Simonsen", new Track[]
                {
                    new Track("Pullet Mullet", Lofi),
                    new Track("Living", Trap),
                    new Track("Heavy Rain", Lofi),
                    new Track("Rising", Hardcore),
                    new Track("Sky High", Psytrance),
                    new Track("Back Home", MelDubstep),
                    new Track("Breeze", Lofi, Trap),
                    new Track("Overhalf", Hardcore),
                    new Track("Powerless", Dudududu),
                    new Track("Savanna", Dudududu),
                    new Track("The Beginning", Hardcore, Dudududu),
                    new Track("Chicken Wrap", Trap),
                    new Track("Synthy Sytro", Electro, Dudududu),
                    new Track("Exploring Beyond Limits", Dudududu),
                    new Track("Be Prepared", ProgHouse),
                    new Track("Fake Reality", GeneralEDM),
                    new Track("Toxicore", ProgHouse),
                    new Track("Achievement Unlocked", Electro),
                    new Track("Upcoming", House),
                    new Track("Come Back", GeneralEDM),
                    new Track("Back to When", House),
                    new Track("Awaiting", House),
                    new Track("Nearing the Ending", House),
                    new Track("Summer", ProgHouse),
                    new Track("Do Nothing", TropHouse),
                    new Track("Take Off", House),
                    new Track("What Mom Request", House),
                    new Track("Bubble", ProgHouse),
                    new Track("Præstentation", Hardcore),
                    new Track("Peacful Harmony", Acoustic),
                    new Track("Dreams", ProgDream),
                    new Track("The Hunters", Trap),
                    new Track("Haunted", House),
                    new Track("Snowflake", ProgHouse),
                    new Track("Worried", Dudududu),
                    new Track("Reuniting", EDMTrap),
                    new Track("Abe-katten Carl", Hardcore),
                    new Track("Morgenfest", Psytrance),
                    new Track("Amplified", Dudududu),
                    new Track("Sample Fun", ProgHouse),
                    new Track("Rain", EDMTrap),
                    new Track("Miracle", Dudududu),
                    new Track("Emmaaa - Bonus Track", Bounce),
                    new Track("Partner", Dudududu),
                    new Track("Not so Pretty", Hardstyle)
                }, new Track[]
                {
                    new Track("Unity", Dudududu),
                    new Track("Play", Dudududu),
                    new Track("bad guy", Dudududu),
                    new Track("From Paris to Berlin", Dudududu, Hardcore),
                    new Track("Nova", Dudududu)
                }),
                new Artist("Darren Styles", new Track[]
                {
                    new Track("Us Against the World", Hardcore)
                }, new Track[]
                {
                    new Track("Hewwego", Hardcore)
                }),
                new Artist("DCX", new Track[]
                {
                    new Track("Flying High (Dubstep Remix)", Dubstep),
                    new Track("Keep on Dancing", ProgPop),
                    new Track("Intensify", EDMTrap)
                }),
                new Artist("Different Heaven", new Track[]
                {
                    new Track("Even Better - Original Mix", Dudududu),
                    new Track("History Of Us", FutBass),
                    new Track("My Heart", Electrio, Electro),
                    new Track("Strangers (feat. Roseanna Brown)", Dudududu, ProgPop)
                }, new Track[]
                {
                    new Track("Ignite (feat. SEUNGRI)", ProgHouse),
                    new Track("MTC", Hardcore),
                    new Track("Old Skool", Electro)
                }),
                new Artist("Dimitri Vegas", new Track[]
                {
                    new Track("Repeat After Me", BigRoom),
                    new Track("Stampede - Edit", BigRoom, Spinnin),
                    new Track("Tales of Tomorrow - Radio Edit", ProgHouse),
                    new Track("Tremor - Radio Edit", BigRoom, Spinnin)
                }),
                new Artist("Disfigure", new Track[]
                {
                    new Track("Black", Dudududu),
                    new Track("I Break Down", MelDubstep),
                    new Track("Summer Tune", Drumstep),

                }),
                new Artist("DJ Gollum", new Track[]
                {
                    new Track("Madness - Cascada, feat. DJ Cap Radio Edit", HandsUp),
                    new Track("Handzup Isn't Dead (8 Years Technobase.fm Hymn)", HandsUp),
                    new Track("I'm a Passenger - Radio Edit", HandsUp),
                    new Track("Moonlight", DeepHouse),
                    new Track("Poison (feat. Scarlett) - Nightcore Edit", HandsUp),
                    new Track("All the Things She Said - Nightcore Edit", HandsUp),
                    new Track("The Promiseland (Phillerz Radio Edit)", HandsUp),
                    new Track("Rockstar - Hands Up Radio Edit", HandsUp)
                }),
                new Artist("DVBBS", new Track[]
                {
                    new Track("Immportal (We Live Forever)", BigRoom, Spinnin),
                    new Track("Pyramids (feat. Sajin) - Radio Mix", Bounce),
                    new Track("This Is Dirty - Original Mix", BigRoom, Spinnin)
                }),
                new Artist("Eminence", new Track[]
                {
                    new Track("United", Electro),
                    new Track("Lipstick", Electro),
                    new Track("Falling Stars", ProgDream),
                    new Track("Universe (feat. Meron Ryan)", ProgDream)
                }),
                new Artist("Fall Out Boy", new Track[]
                {
                    new Track("Centuries", RockMetal),
                    new Track("Uma Thurman", RockMetal),
                    new Track("Immortals", RockMetal),
                    new Track("The Carpal Tunnel Of Love", RockMetal),
                    new Track("Thnks fr th Mmrs", RockMetal),
                    new Track("The Last Of The Real Ones", RockMetal),
                    new Track("The Pheonix", RockMetal),
                    new Track("My Songs Know What You Did In The Dark", RockMetal),
                    new Track("Alone Together", RockMetal)
                }),
                new Artist("Heiakim", new Track[]
                {
                    new Track("Hotto Dogu", FutBass),
                    new Track("Matcha Puff!", FutBass),
                    new Track("Omae Wa Mou Lofi Desu", Lofi)
                }),
                new Artist("Hellberg", new Track[]
                {
                    new Track("Air", ProgDream),
                    new Track("The Girl (feat. Cozi Zuehlsdorff)", ProgPop),
                    new Track("I'm Not Over (Radio Edit) [feat. Tash]", ProgPop),
                    new Track("This Is Forever (feat. Danyka Nadeau)", ProgHouse),
                    new Track("Wasted Summer", ProgDream, ProgPop)
                }),
                new Artist("Italobrothers", new Track[]
                {
                    new Track("Boom - Video Edit", HandsUp),
                    new Track("Cryin' In The Rain - Video Edit", HandsUp),
                    new Track("Hasselhoff 2017", ElecHouse, Bounce),
                    new Track("Love Is On Fire - Rob & Chris Radio Edit", HandsUp),
                    new Track("Ocean Breeze", FutBounce, ProgPop),
                    new Track("Pandora 2012 - Video Edit", HandsUp),
                    new Track("Sleep When We're Dead - Video Edit", HandsUp),
                    new Track("Sleep When We're Dead - Club Radio Edit", Bounce),
                    new Track("Stamp On The Ground", HandsUp),
                    new Track("Love Is On Fire", HandsUp),
                    new Track("Radio Hardcore", HandsUp),
                    new Track("Upside Down", HandsUp),
                    new Track("Underwater World", HandsUp),
                    new Track("Colours Of The Rainbow", HandsUp),
                    new Track("Heaven", HandsUp),
                    new Track("So Small - Dance Radio Edit", HandsUp),
                    new Track("Counting Down The Days - Cascada Radio Edit", HandsUp),
                    new Track("It Must Have Been Love", HandsUp),
                    new Track("The Moon", HandsUp),
                    new Track("Put Your Hands Up In The Air", HandsUp),
                    new Track("Where Are You Now", HandsUp),
                    new Track("Moonlight Shadow", HandsUp),
                    new Track("Thie Is Nightlife - Video Edit", FutBounce),
                    new Track("Welcome to the Dancefloor - Video Edit", BigRoom)
                }),
                new Artist("Itro", new Track[]
                {
                    new Track("Alive", ProgDream, NCSStyle),
                    new Track("For You", MelHouse),
                    new Track("I'm In Love", Drumstep),
                    new Track("Panda", NCSStyle),
                    new Track("Magic", MelHouse),
                    new Track("Sea", ProgHouse),
                    new Track("Skyward Bound", NCSStyle)
                }),
                new Artist("Jens O.", new Track[]
                {
                    new Track("Dare - Radio Edit", Bounce),
                    new Track("Hold On 2 Me - Extended Mix", Psytrance),
                    new Track("Raver - Radio Edit", HandsUp)
                }),
                new Artist("Jochen Miller", new Track[]
                {
                    new Track("Attic - Radio Edit", ProgHouse, ElecHouse),
                    new Track("Fearless - Tom Fall Radio Edit", BigRoom),
                    new Track("A Million Pieces - Radio Edit", ProgDream),
                    new Track("Scope", ElecHouse),
                    new Track("Slow Down - Radio Edit", ProgHouse),
                    new Track("Turn It Up - Radio Edit", ElecHouse, BigRoom),
                    new Track("United", BigRoom)
                }),
                new Artist("Joey Moe", new Track[]
                {
                    new Track("Dobbeltslag", HandsUp),
                    new Track("Yo-Yo", HandsUp),
                    new Track("Jorden Er Giftig", HandsUp),
                    new Track("2012 (Det Derfor)", Dubstep),
                    new Track("Dynamit", HandsUp)
                }),
                new Artist("K-391", new Track[]
                {
                    new Track("Different World (feat. CORSAK)", Dudududu),
                    new Track("Ignite", Dudududu),
                    new Track("End of Time", Dudududu),
                    new Track("Story Of Envy", Dudududu),
                    new Track("Electrode", Dudududu),
                    new Track("Electro House 2012", Dudududu),
                    new Track("Dream Of Something Sweet", Dudududu),
                    new Track("Fantastic", Dudududu),
                    new Track("Mystery", Pop),
                    new Track("Earth", Dudududu),
                    new Track("Play", Dudududu),
                    new Track("Summertime", Dudududu),
                    new Track("This Is Felicitas", Dudududu),
                    new Track("Triple Rush", Dudududu)
                }, new Track[]
                {
                    new Track("All Falls Down (feat. Juliander)", Dudududu),
                    new Track("Tired", Dudududu),
                }),
                new Artist("KDrew", new Track[]
                {
                    new Track("Circles - Original", Dubstep),
                    new Track("Bullseye", Dubstep),
                    new Track("Firestarter", Dubstep),
                    new Track("Last Train To Paradise - Original", Dubstep)
                }),
                new Artist("Klaas", new Track[]
                {
                    new Track("Big Words", Bounce),
                    new Track("Call Me When You Need Me", Bounce),
                    new Track("Figure Out", Bounce),
                    new Track("Mr. Saxobeat", Bounce),
                    new Track("Universal - Radio Edit", Bounce)
                }),
                new Artist("Knife Party", new Track[]
                {
                    new Track("Power Glove", Dubstep),
                    new Track("Internet Friends - VIP", Dubstep),
                    new Track("Bonfire", Dubstep)
                }),
                new Artist("Krewella", new Track[]
                {
                    new Track("Surrender The Throne", Drumstep),
                    new Track("Beggars", EDMTrap),
                    new Track("Live for the Night", Electro),
                    new Track("We Go Down", Dubstep),
                    new Track("Enjoy the Ride", ProgPop),
                    new Track("Ring of Fire", BigRoom),
                    new Track("Human", Dubstep),
                    new Track("This Is Not the End", Dubstep),
                    new Track("Ghost", EDMTrap),
                    new Track("Good On You", Pop),
                    new Track("Live for the Night", Electro),
                    new Track("Play Hard", Electro),
                    new Track("Killin' It", Dubstep),
                    new Track("Can't Control Myself", Dubstep),
                    new Track("Alive", ProgPop),
                    new Track("One Minute", Dubstep),
                    new Track("Feel Me", Dubstep),
                    new Track("Come & Get It", Drumstep, Dubstep),
                    new Track("Say Goodbye", Drumstep),
                    new Track("Somewhere to Run", Electro),
                    new Track("Legacy - Radio Edit", Electro),
                    new Track("Another Round", FutHouse),
                    new Track("Greenlights", FutBass)
                }, new Track[]
                {
                    new Track("Alone Together", Drumstep),
                }),
                new Artist("Kygo", new Track[]
                {
                    new Track("Firstone (feat. Conrad Sewell)", TropHouse),
                    new Track("Here for You", TropHouse),
                    new Track("Stay", TropHouse),
                    new Track("Stole the Show", TropHouse)
                }),
                new Artist("Laszlo", new Track[]
                {
                    new Track("Fall To Light", Drumstep),
                    new Track("Home (faet. Richard Caddock)", ProgDream),
                    new Track("Interstellar", ProgDream),
                    new Track("Supernova", ProgDream)
                }),
                new Artist("Lensko", new Track[]
                {
                    new Track("Cetus", Dudududu),
                    new Track("Circles", Dudududu),
                    new Track("Heaven", Dudududu),
                    new Track("Luminous", Dudududu),
                    new Track("Royals 2014 (Feat. Emil Sætran, Maren Dolmen)", Dudududu),
                    new Track("Standby", Dudududu),
                    new Track("Titsepoken 2015", Dudududu)
                }),
                new Artist("Lets Be Friends", new Track[]
                {
                    new Track("FTW", Electro),
                    new Track("Come N Get It", Dubstep),
                    new Track("Manslaughter (VIP Mix)", Dubstep)
                }),
                new Artist("Luh Kel", new Track[]
                {
                    new Track("BRB", Trap),
                    new Track("Cold Heart", Trap),
                    new Track("Movie (feat. PnB Rock)", Trap),
                    new Track("Wrong", Trap)
                }),
                new Artist("Maroon 5", new Track[]
                {
                    new Track("Memories", Pop),
                    new Track("Payphone", Pop),
                    new Track("Annimals", Pop)
                }),
                new Artist("Marshmello", new Track[]
                {
                    new Track("Alone", EDMTrap),
                    new Track("FRIENDS", EDMTrap),
                    new Track("Happier", EDMTrap),
                    new Track("Here With Me", EDMTrap),
                    new Track("Summer", EDMTrap),
                    new Track("Blocks", EDMTrap),
                    new Track("Moving On", EDMTrap),
                    new Track("Silence", EDMTrap)
                }, new Track[]
                {
                    new Track("Sing Me to Sleep", EDMTrap)
                }),
                new Artist("Martin Garrix", new Track[]
                {
                    new Track("Helicopter - Video Edit", BigRoom, Spinnin),
                    new Track("Scared to Be Lonely", FutBass),
                    new Track("These Are The Times (feat. JRM)", ProgPop),
                    new Track("Virus (How About Now)", BigRoom, Spinnin)
                }),
                new Artist("The Material", new Track[]
                {
                    new Track("Life Vest (Acoustic Version)", Acoustic),
                    new Track("Gasoline (Acoustic Version)", Acoustic),
                    new Track("Born to Make a Sound", RockMetal),
                    new Track("Tonight I'm Letting Go", RockMetal),
                    new Track("Bottles", RockMetal),
                    new Track("Gasoline", RockMetal),
                    new Track("Mistakes", RockMetal),
                    new Track("The One That Got Away", RockMetal),
                    new Track("Appearances", RockMetal),
                    new Track("Let You Down", RockMetal),
                    new Track("What we Are", RockMetal),
                    new Track("The Only One", RockMetal)
                }),
                new Artist("My Chemical Romance", new Track[]
                {
                    new Track("Welcome to the Black Parade", RockMetal),
                    new Track("Teenagers", RockMetal),
                    new Track("Na Na Na(Na Na Na Na Na Na Na Na Na", RockMetal),
                    new Track("Bulletproof Heart", RockMetal),
                    new Track("Planetary (GO!)", RockMetal),
                    new Track("The Only Hope for Me Is You", RockMetal),
                    new Track("Party Poison", RockMetal)
                }),
                new Artist("Nicky Romero", new Track[]
                {
                    new Track("I Could Be The One [Avicii vs Nicky Romero] - Nicktim - Radio Edit", ProgPop),
                    new Track("Future Funk - Radio Edit", FutFunk),
                    new Track("Harmony - Original Mix", ProgPop, ProgDream),
                    new Track("Legacy - Radio Edit", Electro),
                    new Track("Let Me Feel - Original Mix", ProgHouse),
                    new Track("Novell - Original Mix", ElecHouse),
                    new Track("Symphonica - Radio Edit", Electro)
                }, new Track[]
                {
                    new Track("I Need Your Love", HandsUp)
                }),
                new Artist("Noisecontrollers", new Track[]
                {
                    new Track("Promises", Hardstyle),
                    new Track("Universe Was Born", Hardstyle),
                    new Track("All Around The World", Hardstyle),
                    new Track("Only You - Original Mix", Dubstep)
                }),
                new Artist("Noisestorm", new Track[]
                {
                    new Track("Breakdown VIP", Electro),
                    new Track("Crab Rave", DeepHouse),
                    new Track("Eclipse", Electro),
                    new Track("Sentinel", EDMTrap),
                    new Track("This Feeling", ElecHouse)
                }),
                new Artist("OMFG", new Track[]
                {
                    new Track("EZ", MelDubstep),
                    new Track("Hello", MelDubstep),
                    new Track("Ice Cream", MelDubstep),
                    new Track("Meant for You", MelDubstep),
                    new Track("Yeah", MelDubstep)
                }),
                new Artist("Panda Eys", new Track[]
                {
                    new Track("Anybody Else, Journey, Pt. 1", Dubstep),
                    new Track("Better Than Ever, Journey, Pt. 1", Dubstep),
                    new Track("Galaxcia", MelDubstep),
                    new Track("Immortal Flame", MelDubstep),
                    new Track("Highscore", MelDubstep),
                    new Track("Colorblind", MelDubstep),
                    new Track("Lonely Island", FutBounce),
                    new Track("Lucid Dream", MelDubstep),
                    new Track("Opposite Side", MelDubstep)
                }),
                new Artist("Panic! At The Disco", new Track[]
                {
                    new Track("Victorious", RockMetal),
                    new Track("Don't Threaten Me with a Good Time", RockMetal),
                    new Track("Emperor's New Clothes", RockMetal),
                    new Track("Death of a Bachelor", Pop),
                    new Track("Crazy = Genius", RockMetal),
                    new Track("LA Devotee", RockMetal),
                    new Track("The Good, the Bad and the Dirty", RockMetal),
                    new Track("House of Memories", Pop),
                    new Track("I Write Sins Not Tragedies", RockMetal),
                    new Track("Say Amen (Saturday Night)", Pop),
                    new Track("Hey Look Ma, I Made It", Pop),
                    new Track("High Hopes", Pop),
                    new Track("Roaring 20s", Pop),
                    new Track("Dancing's Not a Crime", Pop),
                    new Track("Dying in LA", Pop),
                    new Track("This Is Gospel", RockMetal),
                    new Track("Miss Jackson (feat. LOLO)", RockMetal),
                    new Track("Vegas Lights", Pop),
                    new Track("Nicotine", RockMetal),
                    new Track("Girls / Girls / Boys", RockMetal),
                    new Track("The Ballad of Mona Lisa", RockMetal)
                }),
                new Artist("Pegboard Nerds", new Track[]
                {
                    new Track("Another Round", FutHouse),
                    new Track("Bassline Kickin", Electro),
                    new Track("Emergency", Electro),
                    new Track("Here It Comes", Electro),
                    new Track("Hero (feat. Elizaveta)", Dubstep),
                    new Track("2012 (Det Derfor)", Dubstep),
                    new Track("Self Destruct", Dubstep),
                    new Track("Pressure Cooker", Dubstep),
                    new Track("We Are One (feat. Splitbreed)", Dubstep),
                    new Track("Razor Sharp", Dubstep),
                    new Track("Disconnected", Electro),
                    new Track("New Style", Dubstep),
                    new Track("Pink Cloud (feat. Max Collins)", Drumstep),
                    new Track("Just Like That (feat. Johnny Graves)", FutBass),
                    new Track("Downhearted (feat. Jonny Rose)", ElecHouse),
                    new Track("End Is Near (Fire in the Hole VIP)", Dubstep),
                    new Track("Swamp Thing", Bounce)
                }, new Track[]
                {
                    new Track("Live for the Night", Dubstep),
                }),
                new Artist("Pixl", new Track[]
                {
                    new Track("Laundy Matter", Electro),
                    new Track("Sugar Rush", Electro),
                    new Track("This Time", Electro),
                    new Track("Sadbot", FutBounce)
                }, new Track[]
                {
                    new Track("Heartbeat (Pixl Remix) [feat. Collin McLoughlin]", Electro)
                }),
                new Artist("Powfu", new Track[]
                {
                    new Track("when things were arkward", Lofi),
                    new Track("Blue Waves", Lofi),
                    new Track("Long Fights, Short Tempers", Lofi),
                    new Track("Would Look Perfect", Lofi),
                    new Track("Break Ups Suck Ass", Lofi),
                    new Track("Letters in December", Lofi),
                    new Track("im used to it", Lofi),
                    new Track("I Could Never Be Loved", Lofi),
                    new Track("don't fall asleep yet", Lofi),
                    new Track("death bed (coffee for your head) (feat. beabadoobee)", Lofi),
                    new Track("Hide in Your Blue Eyes", Lofi),
                    new Track("Would Look Perfect", Lofi),
                    new Track("All Again", Lofi),
                    new Track("I Love U Dad", Lofi),
                    new Track("My Mattress", Lofi),
                    new Track("ill come back to you", Lofi),
                    new Track("a woeworld of chaos", Lofi),
                    new Track("Are You Okay?", Lofi),
                    new Track("Days We Had", Lofi),
                    new Track("Dead Eyes", Trap),
                    new Track("I Can't Sleep", Trap),
                    new Track("Laying on my porch while we watch the world end.", Trap),
                    new Track("step into my life", Trap),
                    new Track("Met at a Party", Trap),
                    new Track("Breakfast With the Moon", Trap),
                    new Track("Friends (feat. Powfu)", Trap),
                    new Track("Hear my thoughts", Trap),
                    new Track("Lovemark", Trap)
                }),
                new Artist("Project 46", new Track[]
                {
                    new Track("Beautiful (It Hurts)", ProgDream),
                    new Track("Eyes - Radio Mix", ProgDream),
                    new Track("Reasons (feat. Andrew Allen)", ProgDream),
                    new Track("Dreaming", ProgDream),
                    new Track("M.O.a.B (Instrumental Mix)", ProgHouse),
                    new Track("Hasselhoff", ProgHouse),
                    new Track("No One (feat. Matthew Steeper", ProgDream),
                    new Track("You", Bounce)
                }),
                new Artist("Proleter", new Track[]
                {
                    new Track("April Showers", ElecSwing),
                    new Track("Faidherbe Square", ElecSwing),
                    new Track("It Don't Mean a Thing", ElecSwing),
                    new Track("Can't Stop Me", ElecSwing),
                    new Track("Throw It Back (feat. Taskrok)", ElecSwing)
                }),
                new Artist("R3HAB", new Track[]
                {
                    new Track("Exhale", EDMTrap),
                    new Track("Flashlight - Original Mix", BigRoom, Spinnin),
                    new Track("Tiger", Bounce, Spinnin),
                    new Track("Won't Stop Rocking", Bounce, Spinnin)
                }, new Track[]
                {
                    new Track("Blame (feat. John Newman)", BigRoom, Bounce)
                }),
                new Artist("Razihel", new Track[]
                {
                    new Track("Children of the Night", BigRoom),
                    new Track("Cuore ghiacciato (feat. Nese Ikaro)", Trap),
                    new Track("Legends (feat. TeamMate)", EDMTrap)
                }),
                new Artist("Refuzion", new Track[]
                {
                    new Track("Meet Again", Rawstyle),
                    new Track("The Things You Hated", Rawstyle),
                    new Track("Without You - Radio Version", Hardstyle)
                }),
                new Artist("S3RL", songs: new Track[]
                {
                    new Track("Adrenalized 2016 (feat. Lexi)", Hardcore),
                    new Track("Again", Hardcore),
                    new Track("Al Capone 2016 (feat Lexi)", Hardcore),
                    new Track("All That I Need (feat. Kayliana & MC Riddle)", Hardcore),
                    new Track("And I'm Like", Hardcore),
                    new Track("Avaline", Hardcore),
                    new Track("Beat All the Odds", Hardcore),
                    new Track("Berserk", Hardcore),
                    new Track("Bff", Hardcore),
                    new Track("Candy (feat. Sara)", Hardcore),
                    new Track("Casual N00b", Hardcore),
                    new Track("Catchit", Hardcore),
                    new Track("Cherry Pop (feat. Gl!Tch)", Hardcore),
                    new Track("Chillcore (feat. Lexi)", Hardcore),
                    new Track("Click Bait (feat. Gl!Tch)", Hardcore),
                    new Track("Da De da (feat. J0hnny)", Hardcore),
                    new Track("Dance More", Hardcore),
                    new Track("Earth B", Hardcore),
                    new Track("Electric Sky 2016 (feat. Krystal)", Hardcore),
                    new Track("Escape (feat. Emi)", Hardcore),
                    new Track("Feel the Melody (feat. Sara)", Hardcore),
                    new Track("Fire", Hardcore),
                    new Track("The Flying Dutchman 2015 (feat. Tamika)", Hardcore),
                    new Track("Forbidden (feat. Avanna)", Hardcore),
                    new Track("Forever (feat. Sara)", Hardcore),
                    new Track("Friendzoned (feat. Mixie Moon & Mc Offside)", Hardcore),
                    new Track("Fugazi 2016", Hardcore),
                    new Track("Galleriet", Hardcore),
                    new Track("Generic Holiday Song (feat. Sara)", Hardcore),
                    new Track("Genre Police", Hardcore),
                    new Track("Hentai", Hardcore),
                    new Track("Hypnotoad", Hardcore),
                    new Track("I Wanna Stay", Hardcore),
                    new Track("I Will Pick You up (feat. Tamika)", Hardcore),
                    new Track("I'll See You Again (feat. Chi Chi)", Hardcore),
                    new Track("Inspiration", Hardcore),
                    new Track("It's This Again", Hardcore),
                    new Track("Jaded Af (feat. ChiyoKo & MC Riddle)", Hardcore),
                    new Track("JP 2015", Hardcore),
                    new Track("LA 2015 (feat. Lexi)", Hardcore),
                    new Track("The Legend of Link (feat. Mixie Moon)", Hardcore),
                    new Track("Let the Beat Go (feat. J0hnny)", Hardcore),
                    new Track("Like This (feat. Krystal)", Hardcore),
                    new Track("Dealer - Original Mix", Hardcore),
                    new Track("Little Kandi Raver 2012", Hardcore),
                    new Track("Misleading Title (feat. Defi Brilator)", Hardcore),
                    new Track("Mr Vain (feat. Tamika)", Hardcore),
                    new Track("Mtc", Hardcore),
                    new Track("Mtc Saga", Hardcore),
                    new Track("Mtc2 (feat Sonika)", Hardcore),
                    new Track("Music Is My Saviour (feat. Mixie Moon)", Hardcore),
                    new Track("Myten 2016", Hardcore),
                    new Track("Next Time (feat. Zoe VanWest)", Hardcore),
                    new Track("Nightcore This (feat. Tamika)", Hardcore),
                    new Track("Nostalgic (faet. Harri Rush)", Hardcore),
                    new Track("Now That I've Found You (feat. Déja)", Hardcore),
                    new Track("Old Stuff (feat. Minto)", Hardcore),
                    new Track("Operation Doomsday (feat. Sara)", Hardcore),
                    new Track("Over the Rainbow (feat. Sara)", Hardcore),
                    new Track("The Perfect Rave", Hardcore),
                    new Track("Pika Girl", Hardcore),
                    new Track("Planet Rave (feat. Renee)", Hardcore),
                    new Track("The Power of Love of Power", Hardcore),
                    new Track("Princess Bubblegum (feat. Yuki)", Hardcore),
                    new Track("Public Service Announcement", Hardcore),
                    new Track("Put Your Phones up (feat. Minto)", Hardcore),
                    new Track("Quack Pack 2016", Hardcore),
                    new Track("R4v3 B0y (feat. Krystal)", Hardcore),
                    new Track("Ravers Mashup", Hardcore),
                    new Track("Can't Bring Me Down - Original Mix", Hardcore),
                    new Track("Rainbow Girl - Original Mix", Hardcore),
                    new Track("Request", Hardcore),
                    new Track("Scary Movie", Hardcore),
                    new Track("Self Titled", Hardcore),
                    new Track("Shell Shock", Hardcore),
                    new Track("Shoom 2016", Hardcore),
                    new Track("Shoulder Boulders - Original Mix", Hardcore),
                    new Track("Silicon XX", Hardcore),
                    new Track("Sky Rocket", Hardcore),
                    new Track("Sorority House", Hardcore),
                    new Track("Space Invader (feat. Sara)", Hardcore),
                    new Track("Space-Time (feat. Riddle Anne)", Hardcore),
                    new Track("Speechless", Hardcore),
                    new Track("Spoiler Alert", Hardcore),
                    new Track("Starlight Starbright (feat Emi & Razor Sharp)", Hardcore),
                    new Track("Summerbass", Hardcore),
                    new Track("Tell Me What You Want (feat. Tamika)", Hardcore),
                    new Track("Through the Years (feat. Yurino)", Hardcore),
                    new Track("To My Dream (feat. Sara)", Hardcore),
                    new Track("Toxic 2016 (feat. Sara)", Hardcore),
                    new Track("Transformers - Original Mix", Hardcore),
                    new Track("Trillium (feat. Sara)", Hardcore),
                    new Track("Upper Hand 2016 (feat. Lexi)", Hardcore),
                    new Track("Waifu", Hardcore),
                    new Track("Well, That Was Awkward", Hardcore),
                    new Track("What Is a DJ?", Hardcore),
                    new Track("When I Die (Bury Me a Raver) [feat. Razor Sharp & Krystal]", Hardcore),
                    new Track("When I'm There (feat. Nikolett)", Hardcore),
                    new Track("Whirlwind (feat. Krystal)", Hardcore),
                    new Track("Yeah Science", Hardcore),
                    new Track("You Are Mine", Hardcore),
                    new Track("You're My Superhero (feat. Zoe VanWest)", Hardcore),
                    new Track("Press Play Walk Away", Hardcore),
                    new Track("My Girlfriend Is a Raver", Hardcore),
                    new Track("Blow The House", Hardcore),
                    new Track("Wanna Fight Huh?", Hardcore),
                    new Track("The Bass & the Melody", Hardcore)
                }, new Track[]
                {
                    new Track("Neko Nation Anthem (Radio Edit)", Hardcore),
                    new Track("Let It Go", Hardcore)
                }),
                new Artist("Scott Brown", new Track[]
                {
                    new Track("All About You - Original Mix", Hardcore),
                    new Track("Because of You", Hardcore),
                    new Track("Energized", Hardcore),
                    new Track("Taking Drugs? - Original Mix", Hardcore),
                    new Track("Fly With You - Original Mix", Hardcore),
                    new Track("Put Them Up", Hardcore),
                    new Track("The Spark - Happy Hardcore Edit", Hardcore),
                    new Track("To The beat", Hardcore)
                }),
                new Artist("Set It Off", new Track[]
                {
                    new Track("Catch Me If You Can", RockMetal),
                    new Track("So Predictable", RockMetal),
                    new Track("I'll Sleep When I'm Dead", RockMetal),
                    new Track("Nightmare", RockMetal),
                    new Track("Swan Song", Pop),
                    new Track("Plastic Promises", RockMetal),
                    new Track("Dream Catcher", Pop),
                    new Track("Freak Show", RockMetal),
                    new Track("Dad's Song", RockMetal),
                    new Track("I'd Rather Drown", RockMetal),
                    new Track("Partners in Crime (feat. Ash Costello)", RockMetal),
                    new Track("Kill the Lights", RockMetal),
                    new Track("Dancing With The Devil", RockMetal),
                    new Track("The Haunting", RockMetal),
                    new Track("N.M.E.", RockMetal),
                    new Track("Forever Stuck in Our Youth", RockMetal),
                    new Track("Why Worry", RockMetal),
                    new Track("Ancient History", RockMetal),
                    new Track("Bleak December", RockMetal),
                    new Track("Duality", RockMetal),
                    new Track("Wolf in Sheep's Clothing", RockMetal),
                    new Track("Bad Guy", RockMetal),
                    new Track("For You Forever", Pop),
                    new Track("Killer In The Mirror", RockMetal),
                    new Track("Life Afraid", Pop),
                    new Track("Lonely Dance", RockMetal),
                    new Track("Hourglass", Pop),
                    new Track("Differnt Songs", RockMetal),
                    new Track("Go To Bed Angry", Pop),
                    new Track("Criminal Minds", Pop),
                    new Track("No Disrespect", Pop),
                    new Track("Stitch Me Up", RockMetal),
                    new Track("I Want You (Gone)", Pop),
                    new Track("Unopened Windows", RockMetal),
                    new Track("Midnight Thoughts", RockMetal),
                    new Track("Problem", RockMetal),
                    new Track("Something New", RockMetal),
                    new Track("Uncontainable", RockMetal),
                    new Track("Upside Down", Pop),
                    new Track("Diamond Girl", Pop),
                    new Track("Tug of War", RockMetal),
                    new Track("Admit It", RockMetal),
                    new Track("Hypnotized", RockMetal)
                }),
                new Artist("Skrillex", new Track[]
                {
                    new Track("Right In", Dubstep),
                    new Track("Bangarang (feat. Sirah)", Dubstep),
                    new Track("The Devil's Den", Dubstep),
                    new Track("Kyoto (feat. Sirah)", Dubstep),
                    new Track("Summit (feat. Ellie Goulding)", Dubstep),
                    new Track("First of the Year (Equinox)", Dubstep),
                    new Track("Rock 'n' Roll (Will Take You to the Mountain", Dubstep),
                    new Track("Kill EVERYBODY", Dubstep)
                }, new Track[]
                {
                    new Track("Levels", Dubstep),
                }),
                new Artist("Stephen Walking", new Track[]
                {
                    new Track("It Came From Planet Earth", Electro),
                    new Track("Top of the World", Electro),
                    new Track("Ampersand", Electro),
                    new Track("Birthday Cake", Electro),
                    new Track("One Man Moon Band", Electro),
                    new Track("Pizza Planet", Electro),
                    new Track("Too Simple", Dubstep),
                    new Track("Shark City", Electro)
                }),
                new Artist("Stonebank", new Track[]
                {
                    new Track("All Night", Hardcore),
                    new Track("Back to Start", Hardcore),
                    new Track("Be Alright (feat. EMEL)", Hardcore),
                    new Track("Blast from the Past", Electro),
                    new Track("By Your Side (feat. EMEL)", Hardstyle),
                    new Track("The Entity", Electro),
                    new Track("Holding on to Sound (feat. Concept)", Electro),
                    new Track("Life & Death", Electro),
                    new Track("Lift You Up (feat. EMEL)", Hardcore, Psytrance),
                    new Track("Lost Without You", Electro),
                    new Track("Moving On (feat. EMEL)", Electro),
                    new Track("The Only One", Hardcore),
                    new Track("The Pressure", Hardcore),
                    new Track("Ripped to Pieces (feat. EMEL)", Hardcore),
                    new Track("Step up (feat. Whizzkid)", Electro),
                    new Track("Stronger", Hardcore),
                    new Track("Who's Got You Love", Hardcore),

                }, new Track[]
                {
                    new Track("The Girl", Hardcore),
                    new Track("Cold Skin", Hardcore)
                }),
                new Artist("Technikore", new Track[]
                {
                    new Track("Gang Beasts 2018", Hardcore),
                    new Track("Worlds Collide", Hardcore),
                    new Track("Nervous", Hardcore),
                    new Track("Siren - Original Mix", Hardcore),
                    new Track("Without Me - Radio Edit", Hardcore),
                    new Track("Find The Spark", Hardcore)
                }, new Track[]
                {
                    new Track("Pretty Rave Girl", Hardcore)
                }),
                new Artist("Tessa", new Track[]
                {
                    new Track("Ben", Trap),
                    new Track("Fuck Dem Freestyle", Trap),
                    new Track("Okay", Trap),
                    new Track("Sjakalina", Trap),
                    new Track("Snakker For Meget", Trap)
                }),
                new Artist("TheFatRat", new Track[]
                {
                    new Track("MAYDAY", ProgDream),
                    new Track("Monody (feat. Laura Brehm)", FutHouse),
                    new Track("Never Be Alone", FutBass),
                }),
                new Artist("Timmy Trumpet", new Track[]
                {
                    new Track("Freaks - Radio Edit", Bounce),
                    new Track("Hipsta", Bounce),
                    new Track("Nightmare - Radio Edit", Melbourne),
                    new Track("Therapy", Psytrance)
                }),
                new Artist("Tobu", new Track[]
                {
                    new Track("Blessing", MelHouse),
                    new Track("Candyland", MelHouse),
                    new Track("Climb", MelHouse),
                    new Track("Cloud 9", MelHouse),
                    new Track("Colors", MelHouse),
                    new Track("Floating", MelHouse),
                    new Track("Good Times", MelHouse),
                    new Track("Happy Ending", MelHouse),
                    new Track("Higher", MelHouse),
                    new Track("Hope (Original Mix)", MelHouse),
                    new Track("Infectious (Original Mix)", MelHouse),
                    new Track("Let's Go", FutFunk),
                    new Track("Life", MelHouse),
                    new Track("Magic", MelHouse),
                    new Track("Mesmerize", MelHouse),
                    new Track("Natural High", MelHouse),
                    new Track("Dusk", MelHouse),
                    new Track("Running Away", MelHouse),
                    new Track("Seven", MelHouse),
                    new Track("Sprinkles", MelHouse),
                    new Track("Sunburst", MelHouse),
                    new Track("Sweet Story", MelHouse),
                    new Track("You & I (feat. Brenton Mattheus)", MelHouse)
                }, new Track[]
                {
                    new Track("Tired", MelHouse),
                }),
                new Artist("Tristam", new Track[]
                {
                    new Track("Bone Dry", FutHouse),
                    new Track("Crave", MelDubstep),
                    new Track("Far Away", MelDubstep),
                    new Track("Frame of Mind", MelDubstep),
                    new Track("Follow Me", Dubstep),
                    new Track("I Remember", Dubstep),
                    new Track("Who We Are", Dubstep),
                    new Track("Too Simple", Dubstep),
                    new Track("Truth", MelDubstep),
                    new Track("Flight", Dubstep),
                    new Track("Extermination", Dubstep),
                    new Track("Till It's Over", Dubstep),
                    new Track("The Vine", MelDubstep),
                    new Track("I'll Be Gone", FutBass)
                }),
                new Artist("Tut Tut Child", new Track[]
                {
                    new Track("Dragon Pirates", Electro),
                    new Track("Don't Push Me", Electro),
                    new Track("Hummingbird", MelDubstep),
                    new Track("Power Fracture", Electro)
                }),
                new Artist("Twenty One Pilots", new Track[]
                {
                    new Track("Stressed Out", Pop),
                    new Track("Ride", Pop),
                    new Track("Heathens", Pop)
                }),
                new Artist("Ude Af Kontrol", new Track[]
                {
                    new Track("Fejrer Det Hele", Bounce),
                    new Track("FuckBoi", Bounce),
                    new Track("Langt Ude", Bounce),
                    new Track("næ", Bounce),
                    new Track("Op A", Bounce),
                    new Track("Det Halve Ku' Være Nok", Bounce),
                    new Track("Ta' Dine Sko Af", Bounce)
                }),
                new Artist("Varien", new Track[]
                {
                    new Track("Morphine", Downtempo),
                    new Track("Valkyrie (feat. Laura Brehm)", Pop),
                    new Track("Moonlight (feat. Aloma Steele)", FutBass),
                }),
                new Artist("Vicetone", new Track[]
                {
                    new Track("Let Me Feel - Original Mix", ProgHouse),
                    new Track("Angels - Radio Edit", Pop),
                    new Track("Catch Me", Bounce),
                    new Track("Heart - Original Mix", Pop),
                    new Track("Hope", Pop),
                    new Track("I'm On Fire", Pop),
                    new Track("No Way Out - Radio Edit", Pop),
                    new Track("Nothing Stopping Me (feat. Kat Nestel)", Pop),
                    new Track("Pitch Black", GeneralEDM, Spinnin),
                    new Track("What I've Waited for (feat. D. Brown)", Pop)
                }),
                new Artist("Zedd", new Track[]
                {
                    new Track("Good Thing (with Kehlani)", Pop),
                    new Track("I Want You To Know", Pop, Electro),
                    new Track("Beautiful Now", Pop)
                }),
                new Artist("Zomboy", new Track[]
                {
                    new Track("Nuclear (Hands Up)", Dubstep),
                    new Track("City 2 City", Dubstep),
                    new Track("Here to Stay", Dubstep)
                })
            };
    }
}