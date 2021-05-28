using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = Discord.API.ApplicationCommandInteractionData;

namespace Discord.WebSocket
{
    public class SocketSlashCommandData : SocketEntity<ulong>, IApplicationCommandInteractionData
    {
        /// <inheritdoc/>
        public string Name { get; private set; }

        /// <summary>
        ///     The <see cref="SocketSlashCommandDataOption"/>'s recieved with this interaction.
        /// </summary>
        public IReadOnlyCollection<SocketSlashCommandDataOption> Options { get; private set; }

        internal SocketSlashCommandData(DiscordSocketClient client, ulong id)
            : base(client, id)
        {

        }

        internal static SocketSlashCommandData Create(DiscordSocketClient client, Model model, ulong id)
        {
            var entity = new SocketSlashCommandData(client, model.Id);
            entity.Update(model);
            return entity;
        }
        internal void Update(Model model)
        {
            this.Name = model.Name;
            this.Options = model.Options.IsSpecified
                ? model.Options.Value.Select(x => new SocketSlashCommandDataOption(x, this.Discord)).ToImmutableArray()
                : null;
        }

        IReadOnlyCollection<IApplicationCommandInteractionDataOption> IApplicationCommandInteractionData.Options => Options;
    }
}