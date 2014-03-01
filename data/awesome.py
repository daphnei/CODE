import sys

string_cases = ['Name', 'Unit', 'Genre']

def parse_into_correct_format(string):
    tab_separated = string.split('\t')
    split_by_spaces = [s.split(' ') for s in tab_separated]
    without_empties = [filter(lambda x: x != "", s) for s in split_by_spaces]
    with_underscores = ['_'.join(s) for s in without_empties]
    with_types = [s + (' VARCHAR(100)' if s in string_cases else ' FLOAT') for s in with_underscores]
    return ",\n".join(with_types)

def parse_multi(strings):
    num_tests = len(strings) / 2
    result_lines = []
    for i in range(num_tests):
        title, testdata = strings[i*2].strip('\n'), strings[i*2 + 1].strip('\n')
        result_lines.append('CREATE TABLE ' + title + ' (')
        result_lines.append(parse_into_correct_format(testdata))
        result_lines.append(');')

    return result_lines

if __name__ == '__main__':
    filename = sys.argv[1]
    with open(filename, 'r') as f:
        output = parse_multi(f.readlines())
        for line in output:
            print line