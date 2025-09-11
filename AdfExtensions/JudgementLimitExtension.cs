using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
    internal static class JudgementLimitExtension
    {
        public static JudgementLimitOption JudgementLimit(this AdfChart chart)
        {
            return new JudgementLimitOption(chart);
        }


    }

    internal class JudgementLimitOption
    {
        private AdfChart _chart;
        public JudgementLimitOption(AdfChart chart)
        {
            _chart = chart;
        }

        private JudgementLimitDisplayType _displayType;
        public JudgementLimitOption SetDisplayType(JudgementLimitDisplayType displayType)
        {
            _displayType = displayType;
            return this;
        }

        // Images
        private Tuple<string, string, string, string>? _judgementImages { get; set; }
        public JudgementLimitOption SetImages(
            string imageOfPurePerfect,
            string imageOfPerfects,
            string imageOfNoMiss,
            string imageOfNormal
            )
        {
            _judgementImages = new(imageOfPurePerfect, imageOfPerfects, imageOfNoMiss, imageOfNormal);
            return this;
        }

        public IJudgementLimitBuilder GetBuilder()
        {
            if (_displayType == JudgementLimitDisplayType.Images)
            {
                if (_judgementImages is null) { throw new JudgementLimitBuilderException($"Have you called \"{nameof(SetImages)}\"?"); }

                return new JudgementLimitOfImageBuilder(_chart, _judgementImages);
            }
            throw new NotImplementedException();
        }

    }

    internal class JudgementLimitOfImageBuilder : IJudgementLimitBuilder
    {
        private AdfChart _chart;
        private Tuple<string, string, string, string> _judgementImages;
        private string _gid;

        public JudgementLimitOfImageBuilder(AdfChart chart, Tuple<string, string, string, string> judgementImages)
        {
            _chart = chart;
            _judgementImages = judgementImages;

            Random random = new();
            _gid = random.Next(1000000).ToString().PadLeft(6, '0');

        }

        public IJudgementLimitBuilder BuildDisplay(int xPx, int yPx, double scale = 100, double switchDuration = 4d)
        {
            _chart.AddDecorationToChart(new()
            {
                Tag = $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}",
                Depth = ExtensionSharedConstants.JudgementLimitOfImageBuilderDepth,
                Position = new((double)xPx / ExtensionSharedConstants.TileWidth,
                            (double)yPx / ExtensionSharedConstants.TileWidth),
                Scale = new(scale),
                RelativeTo = AdfMoveDecorationRelativeToType.Camera,
                LockRotation = true, LockScale = true
            });

            foreach (var judgement in _judgements)
            {
                _chart.ChartTiles[judgement.Key].TileEvents.Add(new AdfEventMoveDecorations()
                {
                    Tag = $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}",
                    DecorationImage = FromJudgementLimitWindowType(judgement.Value),
                    Scale = new(scale * 1.1),
                    Duration = 0d
                });
                _chart.ChartTiles[judgement.Key].TileEvents.Add(new AdfEventMoveDecorations()
                {
                    Tag = $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}",
                    Scale = new(scale),
                    Duration = _chart.GetTileBpmAt(judgement.Key) / _chart.GetTileBpmAt(0) * switchDuration,
                    Ease = AdfEaseType.OutCirc
                });
            }

            var finalSwitch = _judgements.MaxBy(x => x.Key);
            _chart.ChartTiles[finalSwitch.Key].TileEvents.Add(new AdfEventMoveDecorations()
            {
                Tag = $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}",
                Opacity = 0,
                Duration = _chart.GetTileBpmAt(finalSwitch.Key) / _chart.GetTileBpmAt(0) * switchDuration,
                Ease = AdfEaseType.OutCubic,
                AngleOffset = _chart.GetTileBpmAt(finalSwitch.Key) / _chart.GetTileBpmAt(0) * switchDuration * 2 * 180,
            });

            return this;
        }

        public IJudgementLimitBuilder BuildLimit()
        {
            

            _chart.AddDecorationToChart(new()
            {
                Tag = $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_dummy_{_gid}",
                Depth = ExtensionSharedConstants.JudgementLimitOfImageBuilderDepth,
                Scale = new(0),
                Opacity = 0,
                DecorationImage = _judgementImages.Item1,
                RelativeTo = AdfMoveDecorationRelativeToType.Camera,
                LockRotation = true,
                LockScale = true,
                Parallax = new(100, 100),
                FailHitboxType = AdfHitboxType.Box,
                Hitbox = AdfHitbox.Kill,
            });

            foreach (var judgement in _judgements)
            {
                if (judgement.Value == JudgementLimitWindowType.Normal)
                {
                    _chart.ChartTiles[judgement.Key].TileEvents.Add(new AdfEventSetConditionalEvents());
                    continue;
                }
                
                _chart.ChartTiles[judgement.Key].TileEvents.Add(new AdfEventMoveDecorations()
                {
                    Duration = 0,
                    Tag = $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_dummy_{_gid}",
                    Scale = new AdfScale(11451, 11451),
                    EventTag = $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}"
                });

                _chart.ChartTiles[judgement.Key].TileEvents.Add(new AdfEventSetConditionalEvents()
                {
                    PerfectTag = (((int)judgement.Value) >> 3) % 2 > 0 ? "NONE" : $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}",
                    EarlyPerfectTag = (((int)judgement.Value) >> 2) % 2 > 0 ? "NONE" : $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}",
                    LatePerfectTag = (((int)judgement.Value) >> 2) % 2 > 0 ? "NONE" : $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}",
                    VeryEarlyTag = (((int)judgement.Value) >> 1) % 2 > 0 ? "NONE" : $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}",
                    VeryLateTag = (((int)judgement.Value) >> 1) % 2 > 0 ? "NONE" : $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}",
                    TooLateTag = ((int)judgement.Value) % 2 > 0 ? "NONE" : $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}",
                    TooEarlyTag = ((int)judgement.Value) % 2 > 0 ? "NONE" : $"{ExtensionSharedConstants.JudgementLimitOfImageBuilderPrefix}_{_gid}_event_{judgement.Key}",
                });
            }


            return this;
        }

        private Dictionary<int, JudgementLimitWindowType> _judgements = new();
        public IJudgementLimitBuilder Limit(int tile, JudgementLimitWindowType type)
        {
            _judgements.Add(tile, type);
            return this;
        }


        private string FromJudgementLimitWindowType(JudgementLimitWindowType type)
        {
            return type switch
            {
                JudgementLimitWindowType.PurePerfect => _judgementImages.Item1,
                JudgementLimitWindowType.Perfects => _judgementImages.Item2,
                JudgementLimitWindowType.NoMiss => _judgementImages.Item3,
                JudgementLimitWindowType.Normal => _judgementImages.Item4,
                _ => _judgementImages.Item4
            };
        }

    }



    internal interface IJudgementLimitBuilder
    {
        public IJudgementLimitBuilder Limit(int tile, JudgementLimitWindowType type);
        public IJudgementLimitBuilder BuildDisplay(int xPx, int yPx, double scale = 100, double switchDuration = 4d);
        public IJudgementLimitBuilder BuildLimit();
    }



    internal enum JudgementLimitDisplayType
    {
        Images,
    }

    internal enum JudgementLimitWindowType
    {
        PurePerfect = 0b1000,
        Perfects = 0b1100,
        NoMiss = 0b1110,
        Normal = 0b1111
    }

    [Serializable]
    internal class JudgementLimitBuilderException : Exception
    {
        public JudgementLimitBuilderException()
        {
        }

        public JudgementLimitBuilderException(string? message) : base(message)
        {
        }

        public JudgementLimitBuilderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
