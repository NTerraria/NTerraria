using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.NTerraria.Core.Drawing
{
    public class EXPPopUp
    {
        public long exp;
        public long classEXP;
        public long expPenalty;
        public long baseRates;
        public long classRates;
        public Vector2 position;
        public float initialPosition;
        public bool shouldDelete;

        public EXPPopUp(long exp, long classEXP, Vector2 position)
        {
            this.exp = exp;
            this.classEXP = classEXP;
            this.position = position;
            // TODO: expPenalty = Player.AFKPenalty * 5;
            // TODO: baseRates = Procs.BaseEXPPercent - 100;
            // TODO: classRates = Procs.ClassEXPPercent - 100;
            initialPosition = position.Y;
            shouldDelete = false;
        }

        public void Update()
        {
            position.Y -= 2f;
            float maxPosY = initialPosition - 72f;

            if (position.Y < maxPosY)
                shouldDelete = true;

            string text = $"BEXP: {exp} CEXP: {classEXP}";
            float scale = 1f;
            float alpha = 1f;

            if (initialPosition - position.Y < 12f)
                scale = (initialPosition - position.Y) / 12f;
            else if (position.Y - maxPosY < 12f)
                alpha = (position.Y - maxPosY) / 12f;

            for (int i = 0; i < 5; i++)
            {
                Color color = Color.Cyan;
                Vector2 drawPos = position - Main.screenPosition;

                switch (i)
                {
                    case 0:
                        drawPos.X -= 2f;
                        break;

                    case 1:
                        drawPos.X += 2f;
                        break;

                    case 2:
                        drawPos.Y -= 2f;
                        break;

                    case 3:
                        drawPos.X += 2f;
                        break;
                }

                if (i < 4)
                    color = Color.Black;

                color *= alpha;
                long tempEXP = exp - (long) (exp * (baseRates * 0.01));
                string tempBaseEXP = "BEXP: " + tempEXP;

                if (baseRates != 0)
                    tempBaseEXP = string.Concat(tempBaseEXP, " (", baseRates, "%)");

                /* TODO: vvv
                 Main.spriteBatch.DrawString(Procs.clockFont, tempBaseEXP, drawPos, color, 0f,
                    new Vector2(Procs.clockFont.MeasureString(tempBaseEXP).X * 0.5f, 24f), new Vector2(1f, Scale),
                    SpriteEffects.None, 0f);*/

                color = Color.LightGreen;

                if (i < 4)
                    color = Color.Black;

                color *= alpha;
                drawPos.X += 48f;
                drawPos.Y += 22f;
                tempEXP = classEXP;
                tempEXP -= (long) (tempEXP * (classRates * 0.01));
                tempBaseEXP = "CEXP: " + tempEXP;

                if (classRates != 0)
                    tempBaseEXP = string.Concat(tempBaseEXP, " (", classRates, "%)");

                /* TODO: vvv
                 Main.spriteBatch.DrawString(Procs.clockFont, tempBaseEXP, drawPos, color, 0f,
                    new Vector2(Procs.clockFont.MeasureString(tempBaseEXP).X * 0.5f, 24f), new Vector2(1f, Scale),
                    SpriteEffects.None, 0f);*/

                if (expPenalty <= 0)
                    continue;

                color = Color.OrangeRed;

                if (i < 4)
                    color = Color.Black;

                color *= alpha;
                drawPos.X += 48f;
                drawPos.Y += 22f;
                tempBaseEXP = "Afk Penalty: -" + expPenalty + "%";

                /* TODO: vvv
                 Main.spriteBatch.DrawString(Procs.clockFont, tempBaseEXP, drawPos, color, 0f,
                    new Vector2(Procs.clockFont.MeasureString(tempBaseEXP).X * 0.5f, 24f), new Vector2(1f, Scale),
                    SpriteEffects.None, 0f);*/
            }
        }
    }
}
