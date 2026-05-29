import re

with open('wiki_dump.txt', 'r', encoding='utf-8') as f:
    text = f.read()

# [[link|title]] → title
text = re.sub(r'\[\[[^\]|]*\|([^\]]*)\]\]', r'\1', text)
# [[link]] → link
text = re.sub(r'\[\[([^\]]*)\]\]', r'\1', text)

with open('wiki_clean.txt', 'w', encoding='utf-8') as f:
    f.write(text)

print("Done")